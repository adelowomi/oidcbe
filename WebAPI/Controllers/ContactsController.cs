using System.Collections.Generic;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {

        private readonly IContactAppService _contactAppService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="contactAppService"></param>
        public ContactsController(IContactAppService contactAppService)
        {
            _contactAppService = contactAppService;
        }

        /// <summary>
        /// Http Get Method, to retrieve all the contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/contacts")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<ContactViewModel>>), 200)]
        public IActionResult GetContacts()
        {
            return Ok(_contactAppService.GetContacts());
        }

        [HttpPost]
        [Route("api/contact")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<ContactViewModel>>), 200)]
        public IActionResult CreateNewContact([FromBody] ContactInputModel contact)
        {
            return Ok(_contactAppService.CreateContact(contact));
        }
    }
}
