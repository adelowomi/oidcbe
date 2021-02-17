using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
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


        [HttpGet]
        [Route("api/permit/statuses")]
        [ProducesResponseType(typeof(PermitStatusesResponse), 200)]
        [ProducesResponseType(typeof(PermitStatusesResponse), 400)]
        public IActionResult GetPermitStatuses()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_permitAppService.GetPermitStatuses());
        }


        [HttpGet]
        [Route("api/permit/{id}")]
        [ProducesResponseType(typeof(PermitViewModel), 200)]
        [ProducesResponseType(typeof(PermitViewModel), 400)]
        public IActionResult GetPermitById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_permitAppService.GetPermitsBy(id));
        }
    }
}
