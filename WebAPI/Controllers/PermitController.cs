using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize]
    public class PermitController : ControllerBase
    {
        private readonly IPermitAppService _permitAppService;

        public PermitController(IPermitAppService permitAppService)
        {
            _permitAppService = permitAppService;
        }

        [HttpGet]
        [Route("api/permits/all")]
        [ProducesResponseType(typeof(PermitsResponse), 200)]
        [ProducesResponseType(typeof(PermitsResponse), 400)]
        public IActionResult GetAllPermits()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_permitAppService.GetPermits());
        }

        [HttpPost]
        [Route("api/permit")]
        [ProducesResponseType(typeof(PermitResponse), 200)]
        [ProducesResponseType(typeof(PermitResponse), 400)]
        public IActionResult CreatePermit([FromBody] PermitInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_permitAppService.CreatePermit(model).Result);
        }


        [HttpGet]
        [Route("api/permit/types")]
        [ProducesResponseType(typeof(PermitTypeResponse), 200)]
        [ProducesResponseType(typeof(PermitTypeResponse), 400)]
        public IActionResult GetPermitType()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_permitAppService.GetPermitTypes());
        }

        [HttpGet]
        [Route("api/permit/current/user")]
        [ProducesResponseType(typeof(PermitsResponse), 200)]
        [ProducesResponseType(typeof(PermitsResponse), 400)]
        public IActionResult GetCurrentUserPermit()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_permitAppService.GetPermitsBy().Result);
        }

        [HttpGet]
        [Route("api/vehicle/types")]
        [ProducesResponseType(typeof(VehicleTypeResponse), 200)]
        [ProducesResponseType(typeof(VehicleTypeResponse), 400)]
        public IActionResult GetVehicleTypes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_permitAppService.GetVehicleTypes());
        }
    }
}
