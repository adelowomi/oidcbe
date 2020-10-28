using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
   
    public class StatesController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStateAppService _stateAppService;

        public StatesController(IUserService userService,
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            IStateAppService stateAppService)
        {
            _userService = userService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _stateAppService = stateAppService;
        }

        [Authorize(Policy = "PlotPolicy")]
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
        [Route("api/state/{stateName}")]
        public IActionResult GetStateBy(string stateName)
        {
            return Ok(ResponseViewModel.Ok(_stateAppService.GetStateByIts(stateName)));
        }
    }
}
