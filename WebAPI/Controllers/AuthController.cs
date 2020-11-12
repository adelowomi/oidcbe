using System.Security.Claims;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize(Policy = "PlotPolicy")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IUserService userService, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Get Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] LoginInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _userService.AuthenticateAsync(model));
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/auth/register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseViewModel.Error("Validation error, please enter the require fields"));
            }

            return Ok(await _userService.RegisterAsync(model));
        }

        /// <summary>
        /// Update User's Profile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut]
        [Route("api/auth/profile/completion")]
        public async Task<IActionResult> ProfileUpdate([FromBody] VendorInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _userService.UpdateVendorAsync(model));
        }


        /// <summary>
        /// Get Reset Token (i.e. Link or Code)
        /// </summary>
        /// <param name="email"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("api/auth/reset-password")]
        public async Task<IActionResult> GetResetToken(string email, string platform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _userService.ResetPasswordAsync(email, platform);

            if (result.Status)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        /// <summary>
        /// Complete Reset Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut]
        [Route("api/auth/complete-reset")]
        public async Task<IActionResult> CompleteResetAsync([FromBody] CompleteForgotPasswordInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _userService.CompleteResetPasswordAsync(model);

            if (result.Status)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [AllowAnonymous]
        [Route("api/auth/change-password")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _userService.ChangePasswordAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// Get Current Logged On Vendor Details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("api/auth/details")]
        public IActionResult VendorDetails()
        {
            return Ok( _userService.GetUserDetails());
        }

        /// <summary>
        /// Request For An OTP or Link
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("api/auth/request-otp")]
        public IActionResult RequestOtp(string emailAddress, string platform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_userService.RequestForOTP(emailAddress, platform));
        }

        /// <summary>
        /// Confirm OTP Code Or Confirmation Link
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("api/auth/confirm-otp")]
        public IActionResult ConfirmOTP ([FromBody] ConfirmOTPInputModel request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_userService.ConfirmOTP(request));
        } 
    }
}