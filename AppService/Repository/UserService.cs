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
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Repository.Abstractions;

namespace AppService.Repository
{
    
    public class UserService : IUserService
    {
        protected readonly AppSettings _appSettings;
        protected readonly UserManager<AppUser> _userManager;
        protected readonly SignInManager<AppUser> _signInManager;
        protected readonly RoleManager<Role> _roleManager;
        protected readonly IMapper _mapper;
        protected readonly IUtilityRepository _utilityRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;
        private readonly AppDbContext _context;
        private readonly IStateService _stateService;

        public UserService(IOptions<AppSettings> appSettings,
                           IMapper mapper,IEmailService emailService,
                           IHttpContextAccessor httpContextAccessor,
                           IUtilityRepository utilityRepository,
                           UserManager<AppUser> userManager,
                           SignInManager<AppUser> signInManager,
                           AppDbContext context,
                           RoleManager<Role> roleManager,
                           IStateService stateService)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _utilityRepository = utilityRepository;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
            _context = context;
            _roleManager = roleManager;
            _stateService = stateService;
        }

        public async Task<ResponseViewModel> AuthenticateAsync(LoginInputModel model)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                AppUser user = new AppUser();

                if (!result.Succeeded) return ResponseViewModel.Create(false)
                            .AddStatusCode(ResponseErrorCodeStatus.INVALID_CREDENTIALS)
                            .AddStatusMessage(ResponseMessageViewModel.INVALID_CREDENTIALS);

                //Find User by Email Address after successful Authentication
                user = await _userManager.FindByEmailAsync(model.Email);

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);


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
                //mappedUser.Gender = _utilityRepository.GetGenderById(user.GenderId)?.Name;

                return ResponseViewModel.Create(true)
                    .AddData(mappedUser)
                    .AddStatusCode(ResponseErrorCodeStatus.OK)
                    .AddStatusMessage(ResponseMessageViewModel.AUTHENTICATION_SUCCESSFUL);

            }
            catch (Exception e)
            {
                //Added Comment
                return ResponseViewModel.Create(false, ResponseMessageViewModel.UNSUCCESSFUL).AddStatusCode(ResponseErrorCodeStatus.FAIL).AddData(e);
            }
        }

        private void AddRolesToClaims(List<Claim> claims, IEnumerable<string> roles)
        {
            foreach (var role in roles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, role);
                claims.Add(roleClaim);
            }
        }

        public async Task<ResponseViewModel> RegisterAsync(RegisterInputModel model)
        {
            try
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                _ = await _userManager.AddToRoleAsync(user, "Admin");
               // _ = _emailService.SendEmail(model.Email, "Account Setup", "Welcome to OIDC");
           
                if (!result.Succeeded) return ResponseViewModel.Error($"Unable to create account. {result.Errors.First().Description} ", ResponseErrorCodeStatus.ACCOUNT_ALREADY_EXIST);

                var mappedUser = _mapper.Map<AppUser, RegisterViewModel>(user);

                return ResponseViewModel.Create(true).AddStatusMessage(ResponseMessageViewModel.SUCCESSFUL).AddData(mappedUser).AddStatusCode(ResponseErrorCodeStatus.OK);

            }
            catch (Exception e)
            {
                return ResponseViewModel.Create(false, ResponseMessageViewModel.UNSUCCESSFUL).AddStatusCode(ResponseErrorCodeStatus.FAIL).AddData(e);
            }
        }


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
                        currentUser.ProfilePhoto = model.SaveProfilePhoto(_appSettings);
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

        public async Task<ResponseViewModel> UpdateVendorAsync(VendorInputModel model)
        {
            try
            {
                AppUser currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

                if (currentUser  != null)
                {

                    currentUser.FirstName = model.FirstName;
                    currentUser.LastName = model.LastName;
                    currentUser.MiddleName = model.MiddleName;
                    currentUser.PhoneNumber = model.PhoneNumber;
                    currentUser.ResidentialAddress = model.ResidentialAddress;
                    currentUser.MailingAddress = model.MailingAddress;

                    if (!string.IsNullOrEmpty(model.ProfilePhoto) && model.IsProfilePhotoChanged)
                    {
                        currentUser.ProfilePhoto = model.SaveProfilePhoto(_appSettings);
                    }

                    if (!string.IsNullOrEmpty(model.IdentityDocument) && model.IsIdentityDocumentChanged)
                    {
                        currentUser.IdentityDocument = model.SaveIdentityDocument(_appSettings);
                    }

                    var gender = _utilityRepository.GetGenderByName(model.Gender);

                    if (gender == null)
                    {
                        return ResponseViewModel.Failed(ResponseMessageViewModel.INVALID_GENDER, ResponseErrorCodeStatus.INVALID_GENDER);
                    }

                    currentUser.GenderId = gender.Id;

                    var state = _stateService.GetState(model.StateOfOriginId);

                    if (state == null)
                    {
                        return ResponseViewModel.Failed(ResponseMessageViewModel.INVALID_GENDER, ResponseErrorCodeStatus.INVALID_STATE);
                    }

                    currentUser.StateOfOriginId = state.Id;

                    //if(currentUser)
                    if (model.NextOfKin != null)
                    {
                        var nextOfKin = _mapper.Map<VendorNextOfKinInputModel, NextOfKin>(model.NextOfKin);

                        nextOfKin.AppUserId = currentUser.Id;

                        var nextOfKinGender = _utilityRepository.GetGenderByName(model.NextOfKin.Gender);

                        if (nextOfKinGender == null)
                        {
                            return ResponseViewModel.Failed(ResponseMessageViewModel.INVALID_GENDER, ResponseErrorCodeStatus.INVALID_NEXT_OF_KIN_GENDER);
                        }

                        nextOfKin.GenderId = nextOfKinGender.Id;

                        _utilityRepository.AddNextOfKin(nextOfKin);
                    }

                    await _userManager.UpdateAsync(currentUser);

                    var mappedResult = _mapper.Map<AppUser, VendorViewModel>(currentUser);

                    return ResponseViewModel.Create(true).AddStatusMessage(ResponseMessageViewModel.SUCCESSFUL).AddData(mappedResult);

                }
                else
                {
                    return ResponseViewModel.Failed();

                }

            }
            catch (Exception e)
            {
                return ResponseViewModel.Create(false, e.Message).AddStatusCode(ResponseErrorCodeStatus.FAIL);
            }
        }

        public IEnumerable<ResponseViewModel> GetAll()
        {
            return null;
        }

        public async Task<ResponseViewModel> ResetPasswordAsync(string email)
        {
            try
            {
                //var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());
                var user = await _userManager.FindByEmailAsync(email);

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                user.Token = token;
                user.OTP = Core.Helpers.Utility.GenerateRandomNumber(4);

                await _userManager.UpdateAsync(user);

                await _emailService.SendEmail(user.Email, "Reset Password", $"You've reset your password. Kinly use {user.OTP} to continue RESET PASSWORD!");

                return ResponseViewModel.Create(true, ResponseMessageViewModel.SUCCESSFUL, new { token });

            }
            catch (Exception e)
            {
                return ResponseViewModel.Create(true, ResponseMessageViewModel.SUCCESSFUL);
            }
        }

        public async Task<ResponseViewModel> CompleteResetPasswordAsync(CompleteForgotPasswordInputModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email); // await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

                if (!user.OTP.Equals(model.OTP))
                {
                    return ResponseViewModel.Create(false, ResponseMessageViewModel.UNSUCCESSFUL);
                }
                var token = await _userManager.ResetPasswordAsync(user, user.Token, model.Password);

                if (token.Succeeded)
                {
                    await _emailService.SendEmail(user.Email, "Reset Password", "You've successfully reset your password");
                }

                return ResponseViewModel.Create(true, ResponseMessageViewModel.SUCCESSFUL, new { token });

            }
            catch (Exception e)
            {
                return ResponseViewModel.Create(false, ResponseMessageViewModel.UNSUCCESSFUL);
            }
        }

        public async Task<ResponseViewModel> ChangePasswordAsync(ChangePasswordInputModel model)
        {
            var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            if (!model.Password.Equals(model.ConfirmPassword))
            {
                return ResponseViewModel.Create(false, ResponseMessageViewModel.PASSWORD_MISMATCH, null);
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.Password);

            if (!result.Succeeded)
            {
                return ResponseViewModel.Error("Unable to change password, please try again");
            }

            await _emailService.SendEmail(user.Email, "Change Password", "You've successfully changed your password");

            return ResponseViewModel.Ok();
        }

        public UserInputModel GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            return _mapper.Map<AppUser, UserInputModel>(user);
        }
    }
}
