using System;
using System.Collections.Generic;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IDocumentAppService
    {
        ResponseViewModel CreateNewDocument(DocumentInputModel document);

        ResponseViewModel GetDocumentsBy();

        DocumentViewModel GetDocumentByName(string name);
    }
}
