using System;
using AppService.AppModel.InputModel;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class BankAccountController : ControllerBase
    {
        private readonly IUtilityAppService _utilityAppService;

        public BankAccountController(IUtilityAppService utilityAppService)
        {
            _utilityAppService = utilityAppService;
        }

        [HttpGet]
        [Route("api/bank/accounts")]
        public IActionResult GetAccounts ()
        {
            return Ok(_utilityAppService.GetAccounts());
        }

        [HttpPost]
        [Route("api/bank/account")]
        public IActionResult PostAccount([FromBody] AccountInputModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_utilityAppService.CreateNewAccount(model));
        }
    }
}
