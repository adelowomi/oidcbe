using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    
    public class SubscriptionController : Controller
    {
       
        private readonly ISubscriptionAppService _subscriptionAppService;

        public SubscriptionController(ISubscriptionAppService subscriptionAppService)
        {
            _subscriptionAppService = subscriptionAppService;
        }


        [HttpPost]
        [Route("api/susbcribe/plot")]
        public IActionResult Subscribe([FromBody] SubscriptionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_subscriptionAppService.MakeSubscription(model).Result));
        }


        [HttpGet]
        [Route("api/susbcribe/plot/available")]
        public IActionResult LogTransaction()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_subscriptionAppService.MakeSubscription().Result));
        }


        [HttpGet]
        [Route("api/subscriptions/all")]
        public IActionResult GetSubscriptionBy()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_subscriptionAppService.GetSubscriptions()));
        }

        [HttpGet]
        [Route("api/subscriptions/user")]
        public IActionResult GetSubscriptionBy(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_subscriptionAppService.GetSubscriptions(userId)));
        }

        //[HttpGet]
        //[Route("api/subscriptions/current")]
        //public IActionResult GetCurrentSubscription()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(ResponseViewModel.Ok(_subscriptionAppService.GetCurrentSubscription()));
        //}
    }
}
