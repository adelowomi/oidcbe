using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private IPlotAppService _plotService;
        private IUtilityAppService _utilityAppService;
        public PaymentsController(IPlotAppService plotService, IUtilityAppService utilityAppService)
        {
            _plotService = plotService;
            _utilityAppService = utilityAppService;
        }


        [HttpGet]
        [Route("api/payments/log")]
        public IActionResult LogTransaction([FromBody] PaymentInputModel payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_plotService.GetByVendorId(1)));
        }

        [HttpGet]
        [Route("api/payments/history")]
        public IActionResult GetPaymentHistory()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_plotService.GetByVendorId(1)));
        }

        [HttpGet]
        [Route("api/payments/providers")]
        public IActionResult GetPaymentProviders()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_plotService.GetByVendorId(1)));
        }

        [HttpGet]
        [Route("api/payments")]
        public IActionResult GetPaymentByTrnxId(int trnxId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_plotService.GetByVendorId(1)));
        }

        [HttpGet]
        [Route("api/payments/requery")]
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
