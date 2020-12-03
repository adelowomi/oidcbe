using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize]
    public class MobilizationController : Controller
    {
        private IMobilizationAppService _mobilizationAppService;
      
        public MobilizationController(IMobilizationAppService mobilizationAppService)
        {
            _mobilizationAppService = mobilizationAppService;
        }


        /// <summary>
        /// Get All Available Mobilization
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/mobilization")]
        public IActionResult GetAllMobilization()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_mobilizationAppService.GetAll());
        }

        /// <summary>
        /// Insert New Mobilization
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/mobilization")]
        public IActionResult CreateNewMobilization([FromBody] MobilizationInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_mobilizationAppService.CreateNew(model).Result);
        }


        /// <summary>
        /// Edit Mobilization
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/mobilization/{id}")]
        public IActionResult UpdateMobilizatoin(int id, [FromBody] MobilizationInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_mobilizationAppService.Update(id, model));
        }


        /// <summary>
        /// Get Mobilization By Plot Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/mobilization/plot/{id}")]
        public IActionResult GetMobilizationById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_mobilizationAppService.GetByPlot(id));
        }

        /// <summary>
        /// Get Mobilization
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/mobilization/user")]
        public IActionResult GetMobilizationById()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_mobilizationAppService.GetByUserAsync().Result);
        }
    }
}
