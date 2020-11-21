using System;
using System.IO;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using AutoMapper;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebAPI.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {

        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly AppSettings _settings;
        private readonly IDocumentAppService _documentAppService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="userManager"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="documentAppService"></param>
        /// <param name="mapper"></param>
        /// <param name="options"></param>
        public DocumentController(IUserService userService, UserManager<AppUser> userManager,
                                IHttpContextAccessor httpContextAccessor,
                                IDocumentAppService documentAppService,
                                IMapper mapper, IOptions<AppSettings> options)
        {
            _userService = userService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _settings = options.Value;
            _documentAppService = documentAppService;
        }

        /// <summary>
        ///  This method returns the raw file of an image, thereby mimicking access over web
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/documents/upload")]
        public IActionResult UploadSurvey([FromBody] DocumentInputModel model)
        {
            return Ok(_documentAppService.CreateNewDocument(model));
        }

        /// <summary>
        /// Get All Documents For Current Logged On User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/documents")]
        public IActionResult GetDocuments([FromBody] DocumentInputModel model)
        {
            return Ok(_documentAppService.GetDocumentsBy());
        }
    }
}
