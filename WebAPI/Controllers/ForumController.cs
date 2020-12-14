using System.Collections.Generic;
using System.Threading.Tasks;
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
    public class ForumController : Controller
    {
        private IForumAppService _forumAppService;

        public ForumController(IForumAppService forumAppService)
        {
            _forumAppService = forumAppService;
        }


        /// <summary>
        /// Get All Available Mobilization
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/forum/messages")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<ForumMessageViewModel>>), 200)]
        public IActionResult GetAllForumMessages()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_forumAppService.GetAllForumMessages());
        }

        /// <summary>
        /// Insert New Mobilization
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/forum/message")]
        [ProducesResponseType(typeof(SwaggerResponse<ForumMessageViewModel>), 200)]
        public IActionResult CreateNewForumMessage([FromBody] ForumMessageInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_forumAppService.CreateNewForum(model));
        }


        /// <summary>
        /// Edit Mobilization
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/forum/message/{id}")]
        [ProducesResponseType(typeof(SwaggerResponse<ForumMessageViewModel>), 200)]
        public IActionResult GetByMessageId(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_forumAppService.GetItById(id));
        }


        /// <summary>
        /// Get Mobilization By Plot Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/forum/{id}")]
        [ProducesResponseType(typeof(SwaggerResponse<ForumViewModel>), 200)]
        public IActionResult GetByForumId(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_forumAppService.GetItById(0, id));
        }

        /// <summary>
        /// Get Mobilization
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/forums")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<ForumViewModel>>), 200)]
        public IActionResult GetForums()
        {
            return Ok(_forumAppService.GetForums());
        }

        /// <summary>
        /// Get Mobilization
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/forum/message/types")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<ForumMessageTypeViewModel>>), 200)]
        public IActionResult GetForumMessages()
        {
           return Ok(_forumAppService.GetForumMessageTypes());
        }


        /// <summary>
        /// Get Mobilization
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/forum/subscriptions")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<SubscriptionViewModel>>), 200)]
        public IActionResult GetAllSubscriptions()
        {
            return Ok(_forumAppService.GetForumSubscriptions());
        }


        /// <summary>
        /// Get Mobilization
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/forum/subscriptions/{id}")]
        [ProducesResponseType(typeof(SwaggerResponse<SubscriptionViewModel>), 200)]
        public IActionResult GetAllSubscriptions(int id)
        {
            return Ok(_forumAppService.GetForumSubscriptions(id));
        }



        /// <summary>
        /// Get Mobilization
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/forum/subscriptions/user/{id}")]
        [ProducesResponseType(typeof(SwaggerResponse<SubscriptionViewModel>), 200)]
        public IActionResult GetUserSubscriptions(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_forumAppService.GetForumSubscriptions(userId));
        }


        /// <summary>
        /// Get Mobilization
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/forum/subscribe/{id}")]
        [ProducesResponseType(typeof(SwaggerResponse<SubscriptionViewModel>), 200)]
        public IActionResult SuscribeToForum(int forumId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_forumAppService.SubscribeToForumAsync(forumId).Result);
        }
    }
}
