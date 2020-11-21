using System;
using System.Collections.Generic;
using Core.Model;

namespace BusinessLogic.Repository.Abstractions
{
    public interface IDocumentService
    {
        IEnumerable<Document> GetAllDocuments();

        IEnumerable<Document> GetDocumentsBy(int userId);

        Document CreateDocument(Document document);

        Document GetDocumentBy(int documentId);

        Document UpdateDocument(Document document);
    }
}
