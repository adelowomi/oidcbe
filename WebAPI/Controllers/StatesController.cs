using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize]
    public class StateController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StateController(IUserService userService, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("api/states")]
        public IActionResult GetAllStates()
        {
            return Ok();
        }

        [HttpPost]
        [Route("api/state/{id}")]
        public IActionResult GetStateBy(int stateId)
        {
            return Ok();
        }
    }
}
