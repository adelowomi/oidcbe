using System.Threading.Tasks;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AppService.Services.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize]
    public class StatesController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStateAppService _stateAppService;
        private readonly IEmailService _emailService;
        private readonly IQRCodeAppService _qRCodeAppService;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="userManager"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="emailService"></param>
        /// <param name="stateAppService"></param>
        public StatesController(IUserService userService,
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            IEmailService emailService,
            IQRCodeAppService qRCodeAppService,
            IStateAppService stateAppService)
        {
            _userService = userService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _stateAppService = stateAppService;
            _emailService = emailService;
            _qRCodeAppService = qRCodeAppService;
        }

        /// <summary>
        /// GET
        /// Get All States
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/states")]
        public IActionResult GetAllStates()
        {
            return Ok(ResponseViewModel.Ok(_stateAppService.GetAllStates()));
        }

        [HttpGet]
        [Route("api/state/{stateId}")]
        public IActionResult GetStateBy(int stateId)
        {
            return Ok(ResponseViewModel.Ok(_stateAppService.GetStateByIts(stateId)));
        }

        [HttpGet]
        [Route("api/state/name/{stateName}")]
        public IActionResult GetStateBy(string stateName)
        {
            return Ok(ResponseViewModel.Ok(_stateAppService.GetStateByIts(stateName)));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/qrcode/test")]
        public async Task<IActionResult> GenerateTestQRCodeAsync()
        {
            //_emailService.SendEmail("liquidcoding2009@gmail.com", "Hey", "How are you?");

            //return Ok(ResponseViewModel.Ok(_stateAppService.GetStateByIts(stateName)));

            var result = await _qRCodeAppService.GenerateCodeAsync();
            
            return Ok(ResponseViewModel.Ok(result));
        }
    }
}
