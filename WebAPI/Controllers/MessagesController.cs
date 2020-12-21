using System.Collections.Generic;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        /// <summary>
        /// Property IForumAppService
        /// </summary>
        private IMessageAppService _messageAppService;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="forumAppService"></param>
        public MessagesController(IMessageAppService messageAppService)
        {
            _messageAppService = messageAppService;
        }

        /// <summary>
        /// Get All Available Mobilization
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/messages")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<MessageViewModel>>), 200)]
        public IActionResult GetMessages()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_messageAppService.GetConversation());
        }


        /// <summary>
        /// Get All Available Mobilization
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/messages/{staffId}")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<MessageViewModel>>), 200)]
        public IActionResult GetMessages(int staffId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_messageAppService.GetConversation(staffId));
        }

        /// <summary>
        /// Register FireBase Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/message")]
        [ProducesResponseType(typeof(SwaggerResponse<MessageViewModel>), 200)]
        public IActionResult CreateNewMessage([FromBody] MessageInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_messageAppService.SendMessage(model));
        }
    }
}
