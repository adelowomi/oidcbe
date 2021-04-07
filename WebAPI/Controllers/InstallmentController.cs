using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class InstallmentController : Controller
    {
        
            private PaymentInstalmentAppService _instalmentService

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="PaymentInstalmentAppService"></param>
            public PaymentInstalmentsController(PaymentInstalmentAppService instalmentService)
            {
                _instalmentService = instalmentService;
            }

            [HttpGet]
            [Route("api/instalments")]
            public IActionResult GetInstalments()
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                return Ok(_instalmentService.GetInstalments());
            }
        
    }
}
