using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize]
    public class WorkOrdersController : Controller
    {
        private readonly IWorkOrderAppService _workOrderAppService;

        public WorkOrdersController(IWorkOrderAppService workOrderAppService)
        {
            _workOrderAppService = workOrderAppService;
        }

        [HttpGet]
        [Route("api/works/all")]
        public IActionResult GetWorkAllOrders()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_workOrderAppService.GetAll()));
        }

        [HttpGet]
        [Route("api/work/current-user")]
        public IActionResult GetWorkOrderForCurrentUser()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_workOrderAppService.GetByUserId().Result));
        }

        [HttpGet]
        [Route("api/works/current-user")]
        public IActionResult GetAllWorkByUserId()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_workOrderAppService.GetAllByUserId().Result));
        }

        [HttpGet]
        [Route("api/work/plot/{id}")]
        public IActionResult GetWorkOrderByPlotId(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_workOrderAppService.GetWorkOrderByPlot(id)));
        }

        [HttpPost]
        [Route("api/work")]
        public IActionResult CreateWorkOrder([FromBody] WorkOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_workOrderAppService.CreateNew(model).Result));
        }


        [HttpGet]
        [Route("api/work/types")]
        public IActionResult GetWorkTypes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(ResponseViewModel.Ok(_workOrderAppService.GetWorkOrderTypes()));
        }
    }
}
