using System;
using System.Collections.Generic;
using System.IO;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebAPI.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {

        private readonly IDocumentAppService _documentAppService;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppSettings _settings;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="documentAppService"></param>
        public DocumentController(IDocumentAppService documentAppService,
                                  UserManager<AppUser> userManager, IOptions<AppSettings> options)
        {
            _documentAppService = documentAppService;
            _userManager = userManager;
            _settings = options.Value;
        }

        /// <summary>
        /// Get All Documents For Current Logged On User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/documents")]
        public IActionResult GetDocuments()
        {
            return Ok(_documentAppService.GetDocumentsBy());
        }

        /// <summary>
        ///  This method returns the raw file of an image, thereby mimicking access over web
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/documents/upload")]
        public IActionResult UploadSurvey([FromBody] DocumentInputModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_documentAppService.CreateNewDocument(model).Result);
        }

       
        [HttpGet]
        [AllowAnonymous]
        [Route("api/documents/link")]
        public IActionResult GetDocumentByName(string name)
        {
            var document = _documentAppService.GetDocumentByName(name);
            var fullPath = Path.Combine(_settings.UploadDrive, _settings.DriveName);
            var file = Path.Combine(fullPath, document.DocumentName);
            Byte[] bytes = System.IO.File.ReadAllBytes(file);
            return File(bytes, "image/jpeg");
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/documents/types")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<DocumentTypeViewModel>>), 200)]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<DocumentTypeViewModel>>), 400)]
        public IActionResult GetDocumentTypse()
        {
            return Ok(_documentAppService.GetDocumentTypes());
        }
    }
}
