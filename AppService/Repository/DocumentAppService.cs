﻿using System;
using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AppService.Helpers;
using AppService.Repository.Abstractions;
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

        public ResponseViewModel CreateNewDocument(DocumentInputModel document)
        {
            var query = _plotService.AllPlots().FirstOrDefault(x => x.Id == document.PlotId);

            if (query == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PLOT, ResponseErrorCodeStatus.INVALID_PLOT);
            }

            var documentType = _documentService.GetAllDocuments();

            if (documentType == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PLOT, ResponseErrorCodeStatus.INVALID_PLOT);
            }

            document.SaveDocument(_settings);

            var user = _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString()).Result;

            document.UserId = user.Id;

            return ResponseViewModel.Ok( _mapper.Map<Document, DocumentViewModel>(
                _documentService.CreateDocument(
                    _mapper.Map<DocumentInputModel, Document>(document))));
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
    }
}
