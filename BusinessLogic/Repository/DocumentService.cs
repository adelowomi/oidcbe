using System;
using System.Collections.Generic;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public Document CreateDocument(Document document)
        {
            return _documentRepository.CreateDocument(document);
        }

        public IEnumerable<Document> GetAllDocuments()
        {
            return _documentRepository.GetAllDocuments();
        }

        public Document GetDocumentBy(int documentId)
        {
            return _documentRepository.GetDocumentBy(documentId);
        }

        public IEnumerable<Document> GetDocumentsBy(int userId)
        {
            return _documentRepository.GetDocumentsBy(userId);
        }

        public Document UpdateDocument(Document document)
        {
            return _documentRepository.UpdateDocument(document);
        }
    }
}
