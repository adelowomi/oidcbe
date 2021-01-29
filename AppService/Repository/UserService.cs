using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AppService.AppModel.InputModel;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using AppService.AppModel.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Infrastructure.DataAccess.DataContext;
using AppService.Extensions;
using AppService.Services.Abstractions;
using Infrastructure.DataAccess.Repository.Abstractions;
using BusinessLogic.Repository.Abstractions;
using Microsoft.AspNetCore.Hosting;
using AppService.Exceptions;
using AppService.Services.ContentServer.Model;
using AppService.Services.ContentServer;

namespace AppService.Repository
{

    /// <summary>
    /// Concrete Implementation IUserService
    /// </summary>
    public class UserService : ResponseViewModel, IUserService
    {
        protected readonly AppSettings _settings;
        protected readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly SignInManager<AppUser> _signInManager;
        protected readonly RoleManager<Role> _roleManager;
        protected readonly IMapper _mapper;
        protected readonly IUtilityRepository _utilityRepository;
        private readonly IEmailService _emailService;
        private readonly AppDbContext _context;
        private readonly IStateService _stateService;
        private readonly IHostingEnvironment _env;
        private readonly IOTPService _otpService;
        private readonly IOTPAppService _otpAppService;

        public UserService(IOptions<AppSettings> appSettings,
                           IMapper mapper, IEmailService emailService,
                           IHttpContextAccessor httpContextAccessor,
                           IUtilityRepository utilityRepository,
                           UserManager<AppUser> userManager,
                           SignInManager<AppUser> signInManager,
                           AppDbContext context,
                           RoleManager<Role> roleManager,
                           IHostingEnvironment env,
                           IOTPService otpService,
                           IOTPAppService otpAppService,
                           IStateService stateService)
        {
            _settings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _utilityRepository = utilityRepository;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
            _context = context;
            _roleManager = roleManager;
            _stateService = stateService;
            _otpService = otpService;
            _otpAppService = otpAppService;
            _env = env;
        }

        /// <summary>
        /// Authenticate Asynchronous Method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResponseViewModel> AuthenticateAsync(LoginInputModel model)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                AppUser user = new AppUser();

                if (!result.Succeeded) return Create(false)
                            .AddStatusCode(ResponseErrorCodeStatus.INVALID_CREDENTIALS)
                            .AddStatusMessage(ResponseMessageViewModel.INVALID_CREDENTIALS);

                //Find User by Email Address after successful Authentication
                user = await _userManager.FindByEmailAsync(model.Email);

                if(string.IsNullOrEmpty(user.GUID))
                {
                    user.GUID = Guid.NewGuid().ToString();
                    await _userManager.UpdateAsync(user);
                }
                
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_settings.Secret);


                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),

                };
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var roles = await _userManager.GetRolesAsync(user);

                AddRolesToClaims(claims, roles);

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                var mappedUser = _mapper.Map<AppUser, UserViewModel>(user);


                if (await _userManager.IsInRoleAsync(user, Res.VENDOR.ToUpper()))
                {
                    mappedUser.UserTypeId = (int)UserTypeEnum.VENDOR;
                }

                if (await _userManager.IsInRoleAsync(user, Res.SUBSCRIBER.ToUpper()))
                {
                    mappedUser.UserTypeId = (int)UserTypeEnum.SUBSCRIBER;
                }

                //mappedUser.Gender = _utilityRepository.GetGenderById(user.GenderId)?.Name;

                return ResponseViewModel.Create(true)
                    .AddData(mappedUser)
                    .AddStatusCode(ResponseErrorCodeStatus.OK)
                    .AddStatusMessage(ResponseMessageViewModel.AUTHENTICATION_SUCCESSFUL);

            }
            catch (Exception e)
            {
                //Added Comment
                return Create(false, ResponseMessageViewModel.UNSUCCESSFUL).AddStatusCode(ResponseErrorCodeStatus.FAIL).AddData(e);
            }
        }


        /// <summary>
        /// Utility Methods to Process Roles's Claims
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="roles"></param>
        private void AddRolesToClaims(List<Claim> claims, IEnumerable<string> roles)
        {
            foreach (var role in roles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, role);
                claims.Add(roleClaim);
            }
        }

        /// <summary>
        /// This Method Handles User Registration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResponseViewModel> RegisterAsync(RegisterInputModel model)
        {
            try
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    GUID = new Guid().ToString()
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if(result.Succeeded) {

                   var emailHtmlTemplate = _emailService.GetEmailTemplate(_env, EmailTemplate.Welcome(model.Platform ?? Res.WEB_PLATFORM));

                    var code = _otpService.GenerateCode(user.Id, _settings.OtpExpirationInMinutes, model.Platform ?? Res.WEB_PLATFORM);

                    Dictionary<string, string> contentReplacements = new Dictionary<string, string>()
                    {
                        { Placeholder.EMAIL, user.Email },
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

                    _ = await _userManager.AddToRoleAsync(user, model.UserType == UserTypeEnum.VENDOR ? UserType.VENDOR : UserType.SUBSCRIBER);
                      
                    var mappedUser = _mapper.Map<AppUser, RegisterViewModel>(user);

                    return ResponseViewModel.Create(true).AddStatusMessage(ResponseMessageViewModel.SUCCESSFUL).AddData(mappedUser).AddStatusCode(ResponseErrorCodeStatus.OK);

                } else {

                   return ResponseViewModel.Error($"{ResponseMessageViewModel.UNABLE_TO_CREATE} {result.Errors.First().Description} ", ResponseErrorCodeStatus.ACCOUNT_ALREADY_EXIST);

                }
            }
            catch (Exception e)
            {
                return ResponseViewModel.Create(false, ResponseMessageViewModel.UNSUCCESSFUL).AddStatusCode(ResponseErrorCodeStatus.FAIL).AddData(e);
            }
        }


        /// <summary>
        /// This Method Handles Completion Of Vendor / Subscriber's Profile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResponseViewModel> UpdateAsync(UserInputModel model)
        {
            try
            {
                var currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());
                 
                if(currentUser != null)
                {
                    currentUser.FirstName = model.FirstName;
                    currentUser.LastName = model.LastName;
                    currentUser.MiddleName = model.MiddleName;
                    currentUser.PhoneNumber = model.PhoneNumber;

                    if (!string.IsNullOrEmpty(model.ProfilePhoto) && model.IsProfilePhotoChanged)
                    {
                        currentUser.ProfilePhoto = model.SaveProfilePhoto(_settings);
                    }

                    var gender = _utilityRepository.GetGenderByName(model.Gender);

                    if (gender == null)
                    {
                        return ResponseViewModel.Failed(ResponseMessageViewModel.INVALID_GENDER, ResponseErrorCodeStatus.INVALID_GENDER);
                    }

                    currentUser.GenderId = gender.Id;

                    await _userManager.UpdateAsync(currentUser);

                    var mappedResult = _mapper.Map<AppUser, UserViewModel>(currentUser);

                    return ResponseViewModel.Create(true).AddStatusMessage(ResponseMessageViewModel.SUCCESSFUL).AddData(mappedResult);

                } else
                {
                    return ResponseViewModel.Failed();
                       
                }
                
            }
            catch (Exception e)
            {
                return ResponseViewModel.Create(false, ResponseMessageViewModel.UNSUCCESSFUL).AddStatusCode(ResponseErrorCodeStatus.FAIL).AddData(e);
            }
        }

        /// <summary>
        /// This Method Update Vendor's Information
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public async Task<ResponseViewModel> UpdateVendorAsync(VendorInputModel model)
        {
            try
            {
                AppUser currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

                if (!currentUser.EmailConfirmed)
                {
                    return Failed(ResponseMessageViewModel.EMAIL_NOT_CONFIRMED, ResponseErrorCodeStatus.EMAIL_NOT_CONFIRMED);
                }

                if (currentUser != null)
                {
                    currentUser.FirstName = model.FirstName;
                    currentUser.LastName = model.LastName;
                    currentUser.MiddleName = model.MiddleName;
                    currentUser.PhoneNumber = model.PhoneNumber;
                    currentUser.ResidentialAddress = model.ResidentialAddress;
                    currentUser.MailingAddress = model.MailingAddress;

                    if (!string.IsNullOrEmpty(model.ProfilePhoto) && model.IsProfilePhotoChanged)
                    {
                        FileDocument uploadResult = FileDocument.Create();

                        try
                        {
                            uploadResult = await
                               BaseContentServer
                               .Build(ContentServerTypeEnum.FIREBASE, _settings)
                               .UploadDocumentAsync(FileDocument.Create(model.ProfilePhoto, $"photo-{currentUser.Id}", currentUser.GUID, FileDocumentType.GetDocumentType(MIMETYPE.IMAGE)));
                        }
                        catch (Exception e)
                        {
                            return Failed(ResponseMessageViewModel.ERROR_UPLOADING_FILE, ResponseErrorCodeStatus.ERROR_UPLOADING_FILE);
                        }

                        currentUser.ProfilePhoto = uploadResult.Path;

                        currentUser.HasUploadedProfilePhoto = !string.IsNullOrEmpty(currentUser.ProfilePhoto);

                    }

                    if (!string.IsNullOrEmpty(model.IdentityDocument) && model.IsIdentityDocumentChanged)
                    {
                        FileDocument uploadResult = FileDocument.Create();

                        try
                        {
                            uploadResult = await
                               BaseContentServer
                               .Build(ContentServerTypeEnum.FIREBASE, _settings)
                               .UploadDocumentAsync(FileDocument.Create(model.IdentityDocument, $"document-{currentUser.Id}", currentUser.GUID, FileDocumentType.GetDocumentType(MIMETYPE.IMAGE)));
                        }
                        catch (Exception e)
                        {
                            return Failed(ResponseMessageViewModel.ERROR_UPLOADING_FILE, ResponseErrorCodeStatus.ERROR_UPLOADING_FILE);
                        }

                        currentUser.IdentityDocument = uploadResult.Path;

                        currentUser.HasUploadedDocument = !string.IsNullOrEmpty(currentUser.IdentityDocument);
                    }

                    var gender = _utilityRepository.GetGenderByName(model.Gender);

                    if (gender == null)
                    {
                        return Failed(ResponseMessageViewModel.INVALID_GENDER, ResponseErrorCodeStatus.INVALID_GENDER);
                    }

                    currentUser.GenderId = gender.Id;

                    var state = _stateService.GetState(model.StateOfOriginId);

                    if (state == null)
                    {
                        return Failed(ResponseMessageViewModel.INVALID_STATE, ResponseErrorCodeStatus.INVALID_STATE);
                    }

                    currentUser.StateOfOriginId = state.Id;

                    if (model.NextOfKin != null)
                    {
                        var nextOfKin = _mapper.Map<VendorNextOfKinInputModel, NextOfKin>(model.NextOfKin);

                        nextOfKin.AppUserId = currentUser.Id;

                        var nextOfKinGender = _utilityRepository.GetGenderByName(model.NextOfKin.Gender);

                        if (nextOfKinGender == null)
                        {
                            return Failed(ResponseMessageViewModel.INVALID_NEXT_OF_KIN_GENDER, ResponseErrorCodeStatus.INVALID_NEXT_OF_KIN_GENDER);
                        }

                        nextOfKin.GenderId = nextOfKinGender.Id;

                        _utilityRepository.AddNextOfKin(nextOfKin);
                    }

                    var userType = _utilityRepository.GetOrganizationType(model.UserTypeId);

                    if(userType == null)
                    {
                        return Failed(ResponseMessageViewModel.INVALID_ORGANIZATION_TYPE, ResponseErrorCodeStatus.INVALID_ORGANIZATION_TYPE);
                    }

                    currentUser.OrganizationTypeId = model.UserTypeId;

                    if(model.UserTypeId == (int) OrganizationEnumType.CORPORATE)
                    {
                        if(string.IsNullOrEmpty(model.RCNumber))
                        {
                            return Failed(ResponseMessageViewModel.INVALID_RC_NUMBER, ResponseErrorCodeStatus.INVALID_RC_NUMBER);
                        }

                        currentUser.RCNumber = model.RCNumber;

                        if(string.IsNullOrEmpty(model.OfficeAddress))
                        {
                            return Failed(ResponseMessageViewModel.INVALID_OFFICE_ADDRESS, ResponseErrorCodeStatus.INVALID_OFFICE_ADDRESS);
                        }

                        currentUser.OfficeAddress = model.OfficeAddress;

                        if (string.IsNullOrEmpty(model.NameOfEntry))
                        {
                            return Failed(ResponseMessageViewModel.INVALID_NAME_NAME_OF_ENTRY, ResponseErrorCodeStatus.INVALID_NAME_NAME_OF_ENTRY);
                        }

                        currentUser.EntryName = model.NameOfEntry;

                        currentUser.WebsiteUrl = model.WebSiteUrl;
                    }

                    await _userManager.UpdateAsync(currentUser);

                    var mappedResult = _mapper.Map<AppUser, VendorViewModel>(currentUser);

                    return Ok().AddStatusMessage(ResponseMessageViewModel.SUCCESSFUL).AddData(mappedResult);
                }
                else
                {
                    return Failed();
                }

            }
            catch (Exception e)
            {
                return Create(false, e.Message).AddStatusCode(ResponseErrorCodeStatus.FAIL);
            }
        }

        /// <summary>
        /// Confirmation OTP Code 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseViewModel ConfirmOTP(ConfirmOTPInputModel model)
        {
            var currentUser = new AppUser().Empty;

            if(string.IsNullOrEmpty(model.Platform))
            {
                return NotFound(ResponseMessageViewModel.INVALID_PLATFORM, ResponseErrorCodeStatus.INVALID_PLATFORM);
            }

            var platform = _otpService.GetPlatformByIts(Res.ZERO, model.Platform);

            if(platform == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PLATFORM, ResponseErrorCodeStatus.INVALID_PLATFORM);
            }

            if ((model.Platform ?? Res.MOBILE_PLATFORM).ToLower() == Res.MOBILE_PLATFORM) {

                 currentUser = _userManager.FindByEmailAsync(model.EmailAddress).Result;

                if (currentUser == null) return Failed(ResponseMessageViewModel.INVALID_EMAIL_ADDRESS).AddStatusCode(ResponseErrorCodeStatus.INVALID_EMAIL_ADDRESS);
            }
            
            try
            {
                _otpAppService.ValidateOTP(currentUser.Id, model.Code, model.Platform);
            }
            catch (InvalidTokenCodeExcepton e)
            {
                return Failed(e.Message, ResponseErrorCodeStatus.INVALID_CONFIRMATION_CODE);
            }
            catch (ExpiredTokenCodeException e)
            {
                return Failed(e.Message, ResponseErrorCodeStatus.EXPIRED_CONFIRMATION_CODE);
            }

            return Ok();
        }
        /// <summary>
        /// Asynchronous Method, To Reset Password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<ResponseViewModel> ResetPasswordAsync(string email, string platform)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (!user.EmailConfirmed)
                {
                    return ResponseViewModel.Failed(ResponseMessageViewModel.EMAIL_NOT_CONFIRMED, ResponseErrorCodeStatus.EMAIL_NOT_CONFIRMED);
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                user.Token = token;

                user.OTP = _otpService.GenerateCode(user.Id, _settings.OtpExpirationInMinutes, platform);

                var emailHtmlTemplate = _emailService.GetEmailTemplate(_env, EmailTemplate.ResetPassword(platform));

                Dictionary<string, string> contentReplacements = new Dictionary<string, string>()
                {
                     { Placeholder.OTP, platform == null ? user.OTP : platform.ToLower() ==  Res.WEB_PLATFORM ? $"{_settings.WebApp.BaseUrl}{_settings.WebApp.ResetPassword}{user.OTP}" : user.OTP },
                     { Placeholder.EXPIRES, $"{_settings.OtpExpirationInMinutes} {Placeholder.MINUTES}" }
                };

                if (contentReplacements != null)
                {
                    foreach (KeyValuePair<string, string> pair in contentReplacements)
                    {
                        emailHtmlTemplate = emailHtmlTemplate.Replace(pair.Key, pair.Value);
                    }
                }

                _ = _emailService.SendEmail(user.Email, Res.REQUEST_PASSWORD_RESET, emailHtmlTemplate);

                await _userManager.UpdateAsync(user);

                return ResponseViewModel.Ok(ResponseMessageViewModel.PASSWORD_RESET_SUCCESSFUL);

            }
            catch (Exception e)
            {
                return ResponseViewModel.Failed(ResponseMessageViewModel.UNKOWN_ERROR, ResponseErrorCodeStatus.UNKOWN_ERROR);
            }
        }


        /// <summary>
        /// Asynchronous Method To Complete Password Change
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResponseViewModel> CompleteResetPasswordAsync(CompleteForgotPasswordInputModel model)
        {
            try
            {
                AppUser user = new AppUser().Empty;

                if (model.Platform.ToLower() == Res.MOBILE_PLATFORM)
                {
                    user  = await _userManager.FindByEmailAsync(model.Email);

                } else
                {
                    var otpCode = _otpService.VerifyToken(model.OtpCode, model.Platform);

                    user = _userManager.FindByIdAsync(otpCode.AppUserId.ToString()).Result;
                }

                if (!user.EmailConfirmed)
                {
                    return ResponseViewModel.Failed(ResponseMessageViewModel.EMAIL_NOT_CONFIRMED, ResponseErrorCodeStatus.EMAIL_NOT_CONFIRMED);
                }

                try
                {
                    _otpAppService.ValidateOTP(user.Id, model.OtpCode, model.Platform);

                }
                catch (InvalidTokenCodeExcepton e) {

                    return ResponseViewModel.Failed(e.Message, ResponseErrorCodeStatus.INVALID_CONFIRMATION_CODE);

                }
                catch (ExpiredTokenCodeException e) {

                    return ResponseViewModel.Failed(e.Message, ResponseErrorCodeStatus.EXPIRED_CONFIRMATION_CODE);

                }

                var token = await _userManager.ResetPasswordAsync(user, user.Token, model.Password);

                if (token.Succeeded)
                {
                    _ = _emailService.SendCompleteResetPassword(user.Email, user.FirstName);

                    return ResponseViewModel.Ok();
                }

                return ResponseViewModel.Failed(ResponseMessageViewModel.UNABLE_TO_RESET_PASSWORD, ResponseErrorCodeStatus.UNABLE_TO_RESET_PASSWORD);

            }
            catch (Exception e)
            {
                return ResponseViewModel.Create(false, ResponseMessageViewModel.UNSUCCESSFUL);
            }
        }

        /// <summary>
        ///  Asynchronous Method to Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResponseViewModel> ChangePasswordAsync(ChangePasswordInputModel model)
        {
            var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            if (!user.EmailConfirmed)
            {
                return ResponseViewModel.Failed(ResponseMessageViewModel.EMAIL_NOT_CONFIRMED, ResponseErrorCodeStatus.EMAIL_NOT_CONFIRMED);
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.Password);

            if (!result.Succeeded)
            {
                return ResponseViewModel.Failed(ResponseMessageViewModel.CHANGE_PASSWORD_FAILED, ResponseErrorCodeStatus.CHANGE_PASSWORD_FAILED);
            }

            return ResponseViewModel.Ok();
        }

        /// <summary>
        /// This Method Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInputModel GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            return _mapper.Map<AppUser, UserInputModel>(user);
        }

        /// <summary>
        ///  This method Returns Current Logged On User Details
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetUserDetails()
        {
            var vendor = _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString()).Result;

            if(!vendor.EmailConfirmed)
            {
                return ResponseViewModel.Failed(ResponseMessageViewModel.EMAIL_NOT_CONFIRMED, ResponseErrorCodeStatus.EMAIL_NOT_CONFIRMED);
            }

            var mappedResult = _mapper.Map<AppUser, VendorViewModel>(vendor);


            return ResponseViewModel.Ok(mappedResult);
        }

        /// <summary>
        ///  Method To Request For A New Token / OTP / Confirmation Code
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public ResponseViewModel RequestForOTP (string emailAddress, string platform)
        {
            try
            {
                var user = _userManager.FindByEmailAsync(emailAddress).Result;

                var code = _otpService.GenerateCode(user.Id, _settings.OtpExpirationInMinutes, platform);

                _ = _emailService.SendRequestTokenEmail(user.Email, code, platform);

                return ResponseViewModel.Ok(ResponseMessageViewModel.CONFIRMATION_CODE_SENT.Replace(Placeholder.EMAIL_PLACEHOLDER, user.Email)).AddStatusCode(ResponseErrorCodeStatus.CONFIRMATION_CODE_SENT);

            } catch (Exception e){

                return ResponseViewModel.Failed(ResponseMessageViewModel.UNKOWN_ERROR, ResponseErrorCodeStatus.UNKOWN_ERROR);

            }
        }

        public async Task<AppUser> GetCurrentLoggedOnUserAsync()
        {
            var currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());
            return currentUser;
        }

        public async Task<AppUser> UpdateCurrentUserAsync(AppUser appUser)
        {

            var result = await _userManager.UpdateAsync(appUser);

            return appUser;
        }

        public async Task<ResponseViewModel> CreateVendor(VendorCreateInputModel model)
        {
            var user = new AppUser
            {
                UserName = model.EmailAddress,
                Email = model.EmailAddress,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };

            var result =  _userManager.CreateAsync(user, "Password").Result;

            if(!result.Succeeded)
            {
                return Failed(ResponseMessageViewModel.UNABLE_TO_CREATE_VENDOR, ResponseErrorCodeStatus.UNABLE_TO_CREATE_VENDOR);
            }

            var task = await _userManager.AddToRoleAsync(user, Res.VENDOR);

            if(!task.Succeeded)
            {
                return Failed(ResponseMessageViewModel.UNABLE_ASSIGN_ROLE_TO_VENDOR, ResponseErrorCodeStatus.UNABLE_ASSIGN_ROLE_TO_VENDOR);
            }

            return Ok();
        }
    }
}
