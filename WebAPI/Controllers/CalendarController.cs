using System;
using System.IO;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using AutoMapper;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebAPI.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {

        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly AppSettings _settings;


        public CalendarController(IUserService userService, UserManager<AppUser> userManager,
                                IHttpContextAccessor httpContextAccessor,
                                IMapper mapper, IOptions<AppSettings> options)
        {
            _userService = userService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _settings = options.Value;
        }

        /// <summary>
        ///  This method returns the raw file of an image, thereby mimicking access over web
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/calendar")]
        public IActionResult UploadSurvey([FromBody] CalendarInputModel model)
        {
            return Ok(ResponseViewModel.Ok());
        }
    }
}
