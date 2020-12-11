using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
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
        [Route("api/plots/current/user")]
        public IActionResult GetByVendorId()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_plotService.GetPlotByCurrentUserAsync().Result));
        }


        /// <summary>
        /// GET Request
        /// Get Vendor By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/plots/all")]
        [ProducesResponseType(typeof(PlotsResponse), 200)]
        [ProducesResponseType(typeof(PlotsResponse), 400)]
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
        [Route("api/plot/{plotId}")]
        public IActionResult GetPlots(int plotId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_plotService.GetByVendorId(plotId));
        }

        /// <summary>
        /// Get Plots
        /// </summary>
        /// <param name="plotId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/plot/{userId}")]
        public IActionResult GetPlotsById(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_plotService.GetByVendorId(userId));
        }


        /// <summary>
        /// Create New Plot Information
        /// </summary>
        /// <param name="plot"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/plot")]
        [ProducesResponseType(typeof(PlotResponse), 200)]
        [ProducesResponseType(typeof(PlotResponse), 400)]
        public IActionResult CreateNewPlot([FromBody] PlotInputModel plot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_plotService.CreatePlot(plot));
        }

        /// <summary>
        /// Create New Plot Information
        /// </summary>
        /// <param name="plot"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/plot/types")]
        [ProducesResponseType(typeof(PlotTypeResponse), 200)]
        [ProducesResponseType(typeof(PlotTypeResponse), 400)]
        public IActionResult GetPlotTypes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_plotService.GetPlotTypes());
        }
    }
}
