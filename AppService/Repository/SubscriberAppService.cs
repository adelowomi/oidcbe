using System.Collections.Generic;
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
using Microsoft.EntityFrameworkCore;

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
        protected readonly IPaymentService _paymentService;
        protected readonly IRequestRepository _requestRepository;

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
                                    IPaymentService paymentService,
                                    IRequestRepository requestRepository,
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
            _paymentService = paymentService;
            _requestRepository = requestRepository;
        }

        public async Task<ResponseViewModel> AddNewSubscriberIndividual(SubcriberIndividualInputModel model)
        {
            var existingUserResult = _userManager.FindByEmailAsync(model.Email).Result;

            if (existingUserResult != null)
            {
                return Failed(ResponseMessageViewModel.ACCOUNT_ALREADY_EXITS, ResponseErrorCodeStatus.ACCOUNT_ALREADY_EXIST);
            }

            var newUser = new AppUser
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                MailingAddress = model.MailingAddress,
                ResidentialAddress = model.ResidentialAddress
            };

            if (!string.IsNullOrEmpty(model.Gender))
            {
                var gender = _utilityRepository.GetGenderByName(model.Gender);

                if (gender != null)
                {
                    newUser.GenderId = gender.Id;
                }
            }

            var result = _subscriberService.CreateSubcribers(newUser);

            if (model.NextOfKin != null)
            {
                var nextOfKin = _mapper.Map<VendorNextOfKinInputModel, NextOfKin>(model.NextOfKin);

                nextOfKin.AppUserId = result.AppUser.Id;

                //var nextOfKinGender = _utilityRepository.GetGenderByName(model.NextOfKin.Gender);

                //if (string.IsNullOrEmpty(nextOfKinGender))
                //{
                //    return Failed(ResponseMessageViewModel.INVALID_NEXT_OF_KIN_GENDER, ResponseErrorCodeStatus.INVALID_NEXT_OF_KIN_GENDER);
                //}

                //nextOfKin.GenderId = nextOfKinGender.Id;

                _utilityRepository.AddNextOfKin(nextOfKin);
            }


            model.SaveIdentityDocument(_settings);

            model.SaveProfilePhoto(_settings);

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

            _ = await _userManager.AddToRoleAsync(result.AppUser, UserType.SUBSCRIBER);

            var mappedResult = _mapper.Map<AppUser,VendorViewModel>(result.AppUser);

            return Ok(mappedResult);
        }

        /// <summary>
        /// Get All Existing Vendor
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VendorViewModel> GetAllExisting()
        {
            var subscribers = _subscriberService.GetExistingSubscribers().Select(_mapper.Map<AppUser, VendorViewModel>);

            foreach (var subscriber in subscribers)
            {
                subscriber.Payments = _paymentService
                    .GetPayments()
                    .Where(x => x.Subscription.AppUserId == subscriber.UserId)
                    .Select(_mapper.Map<Payment, PaymentViewModel>);
            }

            return subscribers;
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

        public async Task<ResponseViewModel> AddNewSubscriberCorporate(SubscriberCorporateInputModel model)
        {

            var existingUserResult = _userManager.FindByEmailAsync(model.Email).Result;

            if (existingUserResult != null)
            {
                return Failed(ResponseMessageViewModel.ACCOUNT_ALREADY_EXITS, ResponseErrorCodeStatus.ACCOUNT_ALREADY_EXIST);
            }

            var result = _subscriberService.CreateSubcribers(new AppUser
            {
                UserName = model.Email,
                FirstName = model.NameOfEntry,
                LastName = model.NameOfEntry,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                RCNumber = model.RCNumber,
                MailingAddress = model.MailingAddress,
                OfficeAddress = model.OfficeAddress,
                WebsiteUrl = model.WebSiteUrl
            });

       
            model.SaveProfilePhoto(_settings);

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

            _ = await _userManager.AddToRoleAsync(result.AppUser, UserType.SUBSCRIBER);

            var mappedResult = _mapper.Map<AppUser, VendorViewModel>(result.AppUser);

            return Ok(mappedResult);
        }

        public async Task<ResponseViewModel> GetSubscriberById(int id)
        {
            //var user = await _userManager.FindByIdAsync(id.ToString());

            var user = _subscriberService.GetExistingSubscribers().FirstOrDefault(x => x.Id == id);

            //Check is In Role _userManager.IsInRoleAsync()

            if(user == null)
            {
                return NotFound(ResponseMessageViewModel.SUBSCRIBER_NOT_EXITS, ResponseErrorCodeStatus.SUBSCRIBER_NOT_EXITS);
            }

            var subscriber = _mapper.Map<AppUser, VendorViewModel>(user);

            subscriber.Payments = _paymentService
                    .GetPayments()
                    .Where(x => x.Subscription.AppUserId == subscriber.UserId)
                    .Select(_mapper.Map<Payment, PaymentViewModel>);
           
            return Ok(subscriber);
        }

        public ResponseViewModel GetSubscribers()
        {
            //var subscribers = _userManager.Users.Include(x => x.Plots).Select(_mapper.Map<AppUser, VendorViewModel>);

            var subscribers = _userManager.GetUsersInRoleAsync(Res.SUBSCRIBER).Result.Select(_mapper.Map<AppUser, VendorViewModel>);

            foreach (var subscriber in subscribers)
            {
                subscriber.Payments = _paymentService
                    .GetPayments()
                    .Where(x => x.Subscription.AppUserId == subscriber.UserId)
                    .Select(_mapper.Map<Payment, PaymentViewModel>);

                subscriber.Requests = _requestRepository.GetAllRequests()
                            .Where(x => x.AppUserId == subscriber.UserId)
                            
                            .Select(_mapper.Map<Request, RequestViewModel>)
                            .ToList();
            }

            return Ok(subscribers);
        }


        public ResponseViewModel GetVendors()
        {
            var vendors = _userManager.GetUsersInRoleAsync(Res.VENDOR).Result.Select(_mapper.Map<AppUser, VendorViewModel>);
            
            foreach (var vendor in vendors)
            {
                vendor.Payments = _paymentService
                    .GetPayments()
                    .Where(x => x.Subscription.AppUserId == vendor.UserId)
                    .Select(_mapper.Map<Payment, PaymentViewModel>);

                vendor.Requests = _requestRepository.GetAllRequests()
                            .Where(x => x.AppUserId == vendor.UserId)

                            .Select(_mapper.Map<Request, RequestViewModel>)
                            .ToList();
            }

            return Ok(vendors);
        }


        public ResponseViewModel GetVendors(int id)
        {
            var vendor = _mapper.Map<AppUser, VendorViewModel>(_userManager.GetUsersInRoleAsync(((int)RoleEnum.VENDOR).ToString()).Result.FirstOrDefault(x => x.Id == id));

            return Ok(vendor);
        }
    }
}
