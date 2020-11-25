using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    
    public class PaymentsController : Controller
    {
        private IPlotAppService _plotService;
        private IUtilityAppService _utilityAppService;
        private readonly IPaymentAppService _paymentAppService;

        public PaymentsController(IPlotAppService plotService, IUtilityAppService utilityAppService, IPaymentAppService paymentAppService)
        {
            _plotService = plotService;
            _utilityAppService = utilityAppService;
            _paymentAppService = paymentAppService;
        }


        [HttpGet]
        [Route("api/payment/log")]
        public IActionResult LogTransaction([FromBody] PaymentInputModel payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_paymentAppService.MakePayment(payment)));
        }

        [HttpGet]
        [Route("api/payment/complete")]
        public IActionResult GetPaymentHistory(string trnxRef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_paymentAppService.QueryPayment(trnxRef)));
        }

        [HttpGet]
        [Route("api/payment/providers")]
        public IActionResult GetPaymentProviders()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_paymentAppService.GetAllPaymentProviders()));
        }

        [HttpGet]
        [Route("api/payment/methods")]
        public IActionResult GetPaymentMethods()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_paymentAppService.GetAllPaymentMethods()));
        }

        [HttpGet]
        [Route("api/payment/statuses")]
        public IActionResult GetPaymentStatuses()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_paymentAppService.GetAllPaymentStatuses()));
        }

        [HttpGet]
        [Route("api/payment/types")]
        public IActionResult GetPaymentTypes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_paymentAppService.GetAllPaymentTypes()));
        }

        [HttpGet]
        [Route("api/payment")]
        public IActionResult GetPaymentByTrnxId(int trnxId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_plotService.GetByVendorId(1)));
        }

        [HttpGet]
        [Route("api/payment/requery")]
        public IActionResult RequeryPaymentByTrnxRef(string trnxRefs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_plotService.GetByVendorId(1));
        }
    }
}
