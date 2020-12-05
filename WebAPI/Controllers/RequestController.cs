using AppService.AppModel.InputModel;
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
        public IActionResult NewRequest([FromBody] RequestInputModel request)
        {
            return Ok(_requestAppService.CreateRequest(request).Result);
        }


        [HttpGet]
        [Route("api/request")]
        public IActionResult GetRequest()
        {
            return Ok(_requestAppService.GetAllRequests());
        }


        [HttpPost]
        [Route("api/request/current/user")]
        public IActionResult GetCurrentUserRequest()
        {
            return Ok(_requestAppService.GetRequestBy().Result);
        }


        [HttpPost]
        [Route("api/request/types")]
        public IActionResult RequestTypes()
        {
            return Ok(_requestAppService.GetRequestTypes());
        }

    }
}
