using AppService.AppModel.InputModel;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        private readonly IRequestAppService _requestAppService;

        public RequestController(IRequestAppService requestAppService)
        {
            _requestAppService = requestAppService;
        }

        [HttpPost]
        [Route("api/request")]
        [ProducesResponseType(typeof(RequestResponse), 200)]
        [ProducesResponseType(typeof(RequestResponse), 400)]
        public IActionResult NewRequest([FromBody] RequestInputModel request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_requestAppService.CreateRequest(request).Result);
        }


        [HttpGet]
        [Route("api/request")]
        [ProducesResponseType(typeof(RequestsResponse), 200)]
        [ProducesResponseType(typeof(RequestsResponse), 400)]
        public IActionResult GetRequest()
        {
            return Ok(_requestAppService.GetAllRequests());
        }


        [HttpGet]
        [Route("api/request/current/user")]
        [ProducesResponseType(typeof(RequestsResponse), 200)]
        [ProducesResponseType(typeof(RequestsResponse), 400)]
        public IActionResult GetCurrentUserRequest()
        {
            return Ok(_requestAppService.GetRequestBy().Result);
        }


        [HttpGet]
        [Route("api/request/types")]
        [ProducesResponseType(typeof(RequestTypesResponse), 200)]
        [ProducesResponseType(typeof(RequestTypesResponse), 400)]
        public IActionResult RequestTypes()
        {
            return Ok(_requestAppService.GetRequestTypes());
        }

        [HttpGet]
        [Route("api/request/approve/{requestId}")]
        [ProducesResponseType(typeof(RequestResponse), 200)]
        [ProducesResponseType(typeof(RequestResponse), 400)]
        public IActionResult ApproveRequest(int requestId)
        {
            return Ok(_requestAppService.Approve(requestId));
        }

        [HttpGet]
        [Route("api/request/decline/{requestId}")]
        [ProducesResponseType(typeof(RequestResponse), 200)]
        [ProducesResponseType(typeof(RequestResponse), 400)]
        public IActionResult DeclineRequest(int requestId)
        {
            return Ok(_requestAppService.Decline(requestId));
        }

        [HttpGet]
        [Route("api/request/suspend/{requestId}")]
        [ProducesResponseType(typeof(RequestResponse), 200)]
        [ProducesResponseType(typeof(RequestResponse), 400)]
        public IActionResult RequestTypes(int requestId)
        {
            return Ok(_requestAppService.Suspended(requestId));
        }

        [HttpGet]
        [Route("api/request/statuses")]
        [ProducesResponseType(typeof(RequestStatusesResponse), 200)]
        [ProducesResponseType(typeof(RequestStatusesResponse), 400)]
        public IActionResult RequestStatus()
        {
            return Ok(_requestAppService.GetRequestStatus());
        }
    }
}
