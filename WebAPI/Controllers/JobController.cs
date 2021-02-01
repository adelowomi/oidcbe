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
    public class JobController : Controller
    {
        private IJobAppService _jobAppService;

        public JobController(IJobAppService jobAppService)
        {
            _jobAppService = jobAppService;
        }


        /// <summary>
        /// Get All Available Jobs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/jobs")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<JobViewModel>>), 200)]
        public IActionResult GetAllForumMessages()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_jobAppService.GetAllJobs());
        }

        /// <summary>
        /// Get All Available Types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/job/types")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<JobTypeViewModel>>), 200)]
        public IActionResult GetAllJobTypes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_jobAppService.GetJobTypes());
        }

        /// <summary>
        /// Get All Available Statuses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/job/statuses")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<JobStatusViewModel>>), 200)]
        public IActionResult GetAllJobStatuses()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_jobAppService.GetJobStatuses());
        }

        /// <summary>
        /// Get All Available Statuses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/job/{id}")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<JobStatusViewModel>>), 200)]
        public IActionResult GetJobBy(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_jobAppService.GetJobBy(id));
        }

        /// <summary>
        /// Get All Available Jobs
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/job")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<JobViewModel>>), 200)]
        public IActionResult CreateJob([FromBody] JobInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_jobAppService.CreateNewJob(model).Result);
        }
    }
}
