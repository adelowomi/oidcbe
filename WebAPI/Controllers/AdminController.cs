﻿using System.Security.Claims;
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
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminController(IUserService userService, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/admin/token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] LoginInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _userService.AuthenticateAsync(model));
        }

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

        //[AllowAnonymous]
        //[HttpPut]
        //[Route("api/admin/update")]
        //public async Task<IActionResult> ProfileUpdate([FromBody] UserInputModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(await _userService.UpdateAsync(model));
        //}

        
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
    }
}