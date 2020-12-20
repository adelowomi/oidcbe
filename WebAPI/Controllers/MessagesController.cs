using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.Repository.Abstractions;
using AppService.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private IForumAppService _forumAppService;

        public MessagesController(IForumAppService forumAppService)
        {
            _forumAppService = forumAppService;
        }


        /// <summary>
        /// Get All Available Mobilization
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/messages")]
        public IActionResult GetMessages()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_forumAppService.GetAllForumMessages());
        }

        /// <summary>
        /// Register FireBase Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/message")]
        public IActionResult CreateNewMessage([FromBody] ForumMessageInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_forumAppService.CreateNewMessageForum(model));
        }

        /// <summary>
        /// Send Push Notification
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/message/{id}")]
        public IActionResult GetMessageByUserId(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_forumAppService.GetById(userId));
        }
    }
}
