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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="plotService"></param>
        public PlotsController (IPlotAppService plotService)
        {
            _plotService = plotService;
        }

        /// <summary>
        /// GET Request
        /// Get Vendor By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/plot")]
        public IActionResult GetByVendorId()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_plotService.GetPlotByCurrentUserAsync()));
        }


        /// <summary>
        /// GET Request
        /// Get Vendor By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/plots")]
        public IActionResult GetPlots()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_plotService.GetPlots()));
        }

        /// <summary>
        /// GET Request
        /// Get Vendor By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/plots/available")]
        public IActionResult GetAvailablePlots()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_plotService.GetAvailablePlots()));
        }

        /// <summary>
        /// Get Plots
        /// </summary>
        /// <param name="plotId"></param>
        /// <returns></returns>
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
