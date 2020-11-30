﻿using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AppService.Services.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Core.Model;
using AppService.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace AppService.Repository
{
    /// <summary>
    /// Concrete Implementation Of ISubscriberAppService
    /// </summary>
    public class SubscriberAppService : ResponseViewModel, ISubscriberAppService
    {
        private readonly ISubscriberService _subscriberService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IHostingEnvironment _env;
        private readonly IOTPService _otpService;
        protected readonly AppSettings _settings;
        protected readonly UserManager<AppUser> _userManager;
        protected readonly IUtilityRepository _utilityRepository;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="subscriberService"></param>
        /// <param name="mapper"></param>
        public SubscriberAppService(ISubscriberService subscriberService,
                                    IMapper mapper, IHostingEnvironment env,
                                    IOTPService otpService,
                                    IUtilityRepository utilityRepository,
                                    UserManager<AppUser> userManager,
                                    IOptions<AppSettings> appSettings,
                                    IEmailService emailService)
        {
            _subscriberService = subscriberService;
            _mapper = mapper;
            _emailService = emailService;
            _env = env;
            _otpService = otpService;
            _settings = appSettings.Value;
            _userManager = userManager;
            _utilityRepository = utilityRepository;
        }

        public async Task<ResponseViewModel> AddNewSubscriberAsync(SubscriberInputModel model)
        {

            var gender = _utilityRepository.GetGenderByName(model.Gender);

            if (gender == null)
            {
                return ResponseViewModel.Failed(ResponseMessageViewModel.INVALID_GENDER, ResponseErrorCodeStatus.INVALID_GENDER);
            }

            var result = _subscriberService.CreateSubcribers(new AppUser
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                GenderId = gender.Id,
                PhoneNumber = model.PhoneNumber
            });

            var emailHtmlTemplate = _emailService.GetEmailTemplate(_env, EmailTemplate.Welcome(model.Platform ?? Res.WEB_PLATFORM));

            var code = _otpService.GenerateCode(result.AppUser.Id, _settings.OtpExpirationInMinutes, model.Platform ?? Res.WEB_PLATFORM);

            Dictionary<string, string> contentReplacements = new Dictionary<string, string>()
                {
                    { Placeholder.EMAIL, result.AppUser.Email },
                    { Placeholder.OTP, (model.Platform ?? Res.WEB_PLATFORM).ToLower() ==  Res.WEB_PLATFORM ? $"{_settings.WebApp.BaseUrl}{_settings.WebApp.Register}{code}" : code },
                };

            if (contentReplacements != null)
            {
                foreach (KeyValuePair<string, string> pair in contentReplacements)
                {
                    emailHtmlTemplate = emailHtmlTemplate.Replace(pair.Key, pair.Value);
                }
            }

            _ = _emailService.SendEmail(model.Email, Res.ACCOUNT_SETUP, emailHtmlTemplate);

            _ = await _userManager.AddToRoleAsync(result.AppUser, model.UserType == UserTypeEnum.VENDOR ? UserType.VENDOR : UserType.VENDOR);

            var mappedResult = _mapper.Map<AppUser,VendorViewModel>(result.AppUser);

            return Ok(mappedResult);
        }

        /// <summary>
        /// Get All Existing Vendor
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VendorViewModel> GetAllExisting()
        {
            var result = _subscriberService.GetExistingSubscribers().Select(_mapper.Map<AppUser, VendorViewModel>);

            return result;
        }

        /// <summary>
        /// Get Counts Metric
        /// </summary>
        /// <returns></returns>
        public CountMetricViewModel GetCountsMetric()
        {
            return new CountMetricViewModel()
            {
                ExistingSubscribers = GetAllExisting().Count(),
                NewSubscribers = GetAllExisting().Count(),
                ExistingVendors = GetAllExisting().Count(),
                NewVendors = GetAllExisting().Count()
            };
        }
    }
}
