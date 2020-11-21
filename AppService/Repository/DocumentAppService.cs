using System;
using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AppService.Repository
{
    public class DocumentAppService : IDocumentAppService
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly UserManager<AppUser> _userManager;

        public DocumentAppService(IDocumentService documentService,
                                  IMapper mapper,
                                  IHttpContextAccessor httpContextAccessor,
                                   UserManager<AppUser> userManager)
        {
            _documentService = documentService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public ResponseViewModel CreateNewDocument(DocumentInputModel document)
        {
            var user = _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString()).Result;

            document.UserId = user.Id;

            return ResponseViewModel.Ok( _mapper.Map<Document, DocumentViewModel>(
                _documentService.CreateDocument(
                    _mapper.Map<DocumentInputModel, Document>(document))));
        }

        public IEnumerable<DocumentViewModel> GetDocumentsBy()
        {
            var user = _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString()).Result;

            return _documentService.GetDocumentsBy(user.Id).Select(_mapper.Map<Document, DocumentViewModel>);
        }
    }
}
