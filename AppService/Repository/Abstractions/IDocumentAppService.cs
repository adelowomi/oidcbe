using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IDocumentAppService
    {
        Task<ResponseViewModel> CreateNewDocument(DocumentInputModel document);

        ResponseViewModel GetDocumentsBy();

        DocumentViewModel GetDocumentByName(string name);
    }
}
