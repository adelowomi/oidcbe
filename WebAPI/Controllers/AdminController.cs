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
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "SUPER ADMIN")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISubscriberAppService _subscriberAppService;
        private readonly ILogger<AdminController> _logger;
            
        public AdminController(IUserService userService,
                                UserManager<AppUser> userManager,
                                ISubscriberAppService subscriberAppService,
                                IHttpContextAccessor httpContextAccessor,
                                ILogger<AdminController> logger)
        {
            _userService = userService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _subscriberAppService = subscriberAppService;
            _logger = logger;
        }

        //}
        /// <summary>
        /// Get Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/admin/token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] LoginInputModel model)
        {
            _logger.LogInformation("Trying To Login");

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
        [Route("api/admin/register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseViewModel.Error("Validation error, please enter the require fields"));
            }

            return Ok(await _userService.RegisterAsync(model));
        }

        /// <summary>
        /// Get Reset Token (i.e. Link or Code)
        /// </summary>
        /// <param name="email"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [AllowAnonymous]
        [Route("api/admin/reset")]
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
        [Route("api/admin/complete-reset")]
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
        [Route("api/admin/change-password")]
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
        [Route("api/admin/details")]
        public IActionResult VendorDetails()
        {
            return Ok(_userService.GetUserDetails());
        }

        /// <summary>
        /// Request For An OTP or Link
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("api/admin/request-otp")]
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
        [Route("api/admin/confirm-otp")]
        public IActionResult ConfirmOTP([FromBody] ConfirmOTPInputModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_userService.ConfirmOTP(request));
        }


        /// <summary>
        /// Confirm OTP Code Or Confirmation Link
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("api/admin/subscriber/individual")]
        public IActionResult CreateIndividual([FromBody] SubcriberIndividualInputModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_subscriberAppService.AddNewSubscriberIndividual(request).Result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/admin/subscriber/corporate")]
        public IActionResult CreateCorporate([FromBody] SubscriberCorporateInputModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_subscriberAppService.AddNewSubscriberCorporate(request).Result);
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("api/admin/subscriber/{id}")]
        public IActionResult GetSubscriberById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_subscriberAppService.GetSubscriberById(id).Result);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/admin/subscribers")]
        public IActionResult GetSubscribers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_subscriberAppService.GetSubscribers());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/admin/vendors")]
        public IActionResult GetVendors()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_subscriberAppService.GetVendors());
        }
    }
}