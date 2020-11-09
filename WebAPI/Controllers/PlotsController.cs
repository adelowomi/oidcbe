using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize]
    public class PlotsController : Controller
    {
        private IPlotAppService _plotService;

        public PlotsController (IPlotAppService plotService)
        {
            _plotService = plotService;
        }

        //[HttpGet]
        //[Route("api/plot/{id}")]
        //public IActionResult GetByPlotId(int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(_plotService.GetPlotById(id));
        //}

        [HttpGet]
        [Route("api/plot)]
        public IActionResult GetByVendorId(int vendorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_plotService.GetByVendorId(vendorId)));
        }

        [HttpGet]
        [Route("api/plot/subscriber)]
        public IActionResult GetBySubcriberId(int subscriberId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_plotService.GetByVendorId(subscriberId)));
        }

        [HttpGet]
        [Route("api/plots/{plotId}")]
        public IActionResult GetPlots(int plotId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_plotService.GetByVendorId(plotId));
        }
    }
}
