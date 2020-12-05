using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IDocumentRepository
    {
        /// <summary>
        /// Get All Documents
        /// </summary>
        /// <returns></returns>
        IEnumerable<Document> GetAllDocuments();

        IEnumerable<Document> GetDocumentsBy(int userId);

        IEnumerable<DocumentType> GetDocumentTypes();

        Document CreateDocument(Document document);

        Document GetDocumentBy(int documentId);

        Document UpdateDocument(Document document);
    }
}
