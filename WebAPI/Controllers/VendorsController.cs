using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    public class VendorsController : ControllerBase
    {
        private IVendorAppService _vendorAppService;

        public VendorsController (IVendorAppService vendorAppService)
        {
            _vendorAppService = vendorAppService;
        }

        [HttpGet]
        [Route("api/vendor")]
        public IActionResult GetVendorById(int vendorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_vendorAppService.GetVendorById(vendorId));
        }

        [HttpGet]
        [Route("api/vendor/{email}")]
        public IActionResult GetVendorByEmail(string emailAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_vendorAppService.GetVendorByEmail(emailAddress));
        }
    }
}
