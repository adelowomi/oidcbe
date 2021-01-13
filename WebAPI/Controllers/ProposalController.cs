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
    public class ProposalController : Controller
    {
        private IProposalAppService _proposalAppService;

        public ProposalController(IProposalAppService proposalAppService)
        {
            _proposalAppService = proposalAppService;
        }


        /// <summary>
        /// Get All Available Proposals
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/proposals")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<ProposalViewModel>>), 200)]
        public IActionResult GetAllForumMessages()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_proposalAppService.GetAllProposals());
        }

        /// <summary>
        /// Get All Available Statuses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/proposal/statuses")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<ProposalViewModel>>), 200)]
        public IActionResult GetAllJobTypes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_proposalAppService.GetProposalStatuses());
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/proposal/{id}")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<ProposalViewModel>>), 200)]
        public IActionResult GetJobBy(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_proposalAppService.GetProposalBy(id));
        }


        /// <summary>
        /// Get By Id
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/proposal/{id}")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<ProposalViewModel>>), 200)]
        public IActionResult MakeProposal([FromBody] ProposalInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_proposalAppService.CreateProposalJob(model));
        }
    }
}
