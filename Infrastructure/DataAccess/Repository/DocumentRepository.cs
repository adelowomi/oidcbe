using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace Infrastructure.DataAccess.Repository
{
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(AppDbContext context) : base(context)
        {

        }

        public Document CreateDocument(Document document)
        {
            document.DateCreated = DateTime.Now;
            document.DateModified = DateTime.Now;
            return CreateAndReturn(document);
        }

        public IEnumerable<Document> GetAllDocuments()
        {
            return GetAll();
        }

        public Document GetDocumentBy(int documentId)
        {
            return GetById(documentId);
        }

        public IEnumerable<Document> GetDocumentsBy(int userId)
        {
            return GetAll().Where(x => x.AppUserId == userId);
        }

        public Document UpdateDocument(Document document)
        {
            Update(document);

            return document;
        }
    }
}
