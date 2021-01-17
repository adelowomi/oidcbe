﻿using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISubscriberAppService _subscriberAppService;
        private readonly IJobAppService _jobAppService;
        private readonly IProposalAppService _proposalAppService;
        private readonly ILogger<AdminController> _logger;
            
        public AdminController(IUserService userService,
                                ISubscriberAppService subscriberAppService,
                                IJobAppService jobAppService,
                                IProposalAppService proposalAppService,
                                ILogger<AdminController> logger)
        {
            _userService = userService;
            _subscriberAppService = subscriberAppService;
            _logger = logger;
            _jobAppService = jobAppService;
            _proposalAppService = proposalAppService;
        }

        //}
        /// <summary>
        /// Get Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/admin/token")]
        [AllowAnonymous]
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
        
        [Route("api/admin/vendors")]
        public IActionResult GetVendors()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_subscriberAppService.GetVendors());
        }

        [HttpGet]
        
        [Route("api/admin/vendor/{id}")]
        public IActionResult GetVendors(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_subscriberAppService.GetVendors(id));
        }

        [HttpPost]
        
        [Route("api/admin/job")]
        public IActionResult CreateJob([FromBody] JobInputModel job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_jobAppService.CreateNewJob(job));
        }


        [HttpPut]
        [AllowAnonymous]
        [Route("api/admin/job")]
        public IActionResult UpdateJob([FromBody] JobInputModel job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_jobAppService.UpdateJob(job));
        }


        [HttpPut]
        
        [Route("api/admin/proposal/approve")]
        public IActionResult Approve(int proposalId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            return Ok(_proposalAppService.ApproveOrDisapprove(2, proposalId));
        }


        [HttpPut]
        
        [Route("api/admin/proposal/decline")]
        public IActionResult Decline(int proposalId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_proposalAppService.ApproveOrDisapprove(3, proposalId));
        }

        [HttpPost]
        [Route("api/admin/vendor/create")]
        public async Task<IActionResult> CreateVendor([FromBody] VendorCreateInputModel vendor)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _userService.CreateVendor(vendor));
        }
    }
}