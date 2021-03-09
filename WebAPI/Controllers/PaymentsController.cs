using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
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


        [HttpPost]
        [Route("api/payment/log")]
        [ProducesResponseType(typeof(PaymentResponse), 200)]
        [ProducesResponseType(typeof(PaymentResponse), 400)]
        public IActionResult LogTransaction([FromBody] PaymentInputModel payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_paymentAppService.MakePayment(payment));
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
        [Route("api/payments")]
        public IActionResult GetAllPayments()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_paymentAppService.GetAllPayments());
        }

        [HttpGet]
        [Route("api/payments/due")]
        public IActionResult GetDuePayments()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_paymentAppService.GetDuePayments());
        }

        [HttpGet]
        [Route("api/payments/approved")]
        public IActionResult GetApprovedPayments()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_paymentAppService.GetApprovedPayments());
        }

        [HttpGet]
        [Route("api/payment/statuses")]
        public IActionResult GetPaymentStatuses()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_paymentAppService.GetAllPaymentStatuses());
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
        public IActionResult GetPaymentById(int paymentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_paymentAppService.GetPaymentById(paymentId));
        }

        [HttpGet]
        [Route("api/payment/requery")]
        public IActionResult RequeryPaymentByTrnxRef(string trnxRefs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_paymentAppService.QueryPayment(trnxRefs));
        }

        [HttpGet]
        [Route("api/payment/history")]
        public IActionResult PaymentHistory()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_paymentAppService.GetPaymentHistory());
        }

        /// <summary>
        /// Get Offer By OfferId
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/payment/cycles")]
        public IActionResult GetPaymentCycles()
        {
            return Ok(_paymentAppService.GetPaymentCycle());
        }

        /// <summary>
        /// Get Offer By OfferId
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/payment/query/{id}")]
        public IActionResult QueryPaymentById(int id)
        {
            return Ok(_paymentAppService.GetPaymentById(id));
        }

        /// <summary>
        /// Allocate Payment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/payment/allocate")]
        public IActionResult PaymentAllocation([FromBody] PaymentAllocationInputModel model) {

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_paymentAppService.PaymentAllocation(model).Result);
        }
    }
}
