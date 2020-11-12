using System;
using System.Linq;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using BusinessLogic.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    
    public class MetricController : Controller
    {

        private readonly ISubscriberAppService _subscriberAppService;

        public MetricController(ISubscriberAppService subscriberAppService)
        {
            _subscriberAppService = subscriberAppService;
        }

        [HttpGet]
        [Route("api/metrics/subscribers/existing")]
        public IActionResult GetExistingSubscribers()
        {
            return Ok(ResponseViewModel.Ok(_subscriberAppService.GetAllExisting().ToList()));
        }

        [HttpGet]
        [Route("api/metrics/subscribers/new")]
        public IActionResult GetNewSubscribers()
        {
            return Ok(ResponseViewModel.Ok(_subscriberAppService.GetAllExisting().ToList()));
        }

        [HttpGet]
        [Route("api/metrics/vendors/existing")]
        public IActionResult GetExistingVendors()
        {
            return Ok(ResponseViewModel.Ok(_subscriberAppService.GetAllExisting().ToList()));
        }

        [HttpGet]
        [Route("api/metrics/vendors/new")]
        public IActionResult GetNewVendors()
        {
            return Ok(ResponseViewModel.Ok(_subscriberAppService.GetAllExisting().ToList()));
        }
    }
}
