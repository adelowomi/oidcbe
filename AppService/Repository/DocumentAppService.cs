using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using AppService.Services.ContentServer;
using AppService.Services.ContentServer.Model;
using AutoMapper;
using BusinessLogic.Repository;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace AppService.Repository
{
    public class DocumentAppService : ResponseViewModel, IDocumentAppService
    {
        private readonly IDocumentService _documentService;
        private readonly IPlotService _plotService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly UserManager<AppUser> _userManager;
        protected readonly AppSettings _settings;

        public DocumentAppService(IDocumentService documentService,
                                  IMapper mapper,
                                  IPlotService plotService,
                                  IOptions<AppSettings> options,
                                  IHttpContextAccessor httpContextAccessor,
                                  UserManager<AppUser> userManager)
        {
            _documentService = documentService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _settings = options.Value;
            _plotService = plotService;
        }

        public async Task<ResponseViewModel> CreateNewDocument(DocumentInputModel document)
        {
            var user = _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString()).Result;

            var query = _plotService.GetByPlotId(document.PlotId);

            if (query == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PLOT, ResponseErrorCodeStatus.INVALID_PLOT);
            }

            var documentType = _documentService.GetDocumentTypes().FirstOrDefault(x => x.Id == document.DocumentType);

            if (documentType == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_DOCUMENT_TYPE, ResponseErrorCodeStatus.INVALID_DOCUMENT_TYPE);
            }

            FileDocument uploadResult = FileDocument.Create();

            try
            {
                uploadResult  = await
                   BaseContentServer
                   .Build(ContentServerTypeEnum.FIREBASE, _settings)
                   .UploadDocumentAsync(FileDocument.Create(document.Document, document.GetDocumentType(), $"{user.GUID}", FileDocumentType.GetDocumentType(MIMETYPE.IMAGE)));

            } catch (Exception e)
            {
                return Failed(ResponseMessageViewModel.ERROR_UPLOADING_FILE, ResponseErrorCodeStatus.ERROR_UPLOADING_FILE);
            }

            var mappedResult = _mapper.Map<DocumentInputModel, Document>(document);

            mappedResult.AppUserId = user.Id;

            mappedResult.Name = uploadResult.Path;

            mappedResult.PlotId = 1010;

            return Ok( _mapper.Map<Document, DocumentViewModel>(_documentService.CreateDocument(mappedResult)));
        }

        public ResponseViewModel GetDocumentsBy()
        {
            var user = _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString()).Result;

            return Ok(_documentService.GetDocumentsBy(user.Id).Select(_mapper.Map<Document, DocumentViewModel>));
        }

        public DocumentViewModel GetDocumentByName(string name)
        {
            return _mapper.Map<Document, DocumentViewModel>(_documentService.GetAllDocuments().First(x => x.Name == name));
        }

        public ResponseViewModel GetDocumentTypes()
        {
            var results = _documentService.GetDocumentTypes().Select(_mapper.Map<DocumentType, DocumentTypeViewModel>);

            return Ok(results);
        }
    }
}
