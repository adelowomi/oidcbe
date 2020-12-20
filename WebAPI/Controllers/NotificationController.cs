using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    public class NotificationController : Controller
    {
        private INotificationAppService _notificationAppService;

        public NotificationController(INotificationAppService notificationAppService)
        {
            _notificationAppService = notificationAppService;
        }


        /// <summary>
        /// Get All Available Mobilization
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/notification")]
        public IActionResult GetNotification()
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
    }
}
