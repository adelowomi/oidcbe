using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(AppDbContext context) : base(context)
        {

        }

        public Document CreateDocument(Document document)
        {
            return CreateAndReturn(document);
        }

        public IEnumerable<Document> GetAllDocuments()
        {
            return _context.Documents
                .Include(x => x.DocumentType)
                .Include(x => x.Plot);
        }

        public Document GetDocumentBy(int documentId)
        {
            return GetAllDocuments().FirstOrDefault(x => x.Id == documentId);
        }

        public IEnumerable<Document> GetDocumentsBy(int userId)
        {
            return GetAllDocuments().Where(x => x.AppUserId == userId);
        }

        public Document UpdateDocument(Document document)
        {
            Update(document);

            return GetDocumentBy(document.Id);
        }
    }
}
