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
        [Route("api/notifications")]
        public IActionResult GetNotification()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_notificationAppService.GetNotifications());
        }

        /// <summary>
        /// Register FireBase Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/notifications/token")]
        public IActionResult CreateNewMobilization([FromBody] NotificationTokenInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_notificationAppService.RegisterToken(model.Token));
        }

        /// <summary>
        /// Send Push Notification
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/notifications/send")]
        public IActionResult SendNotification([FromBody] ForumMessageInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_notificationAppService.NewNotification(model));
        }
    }
}
