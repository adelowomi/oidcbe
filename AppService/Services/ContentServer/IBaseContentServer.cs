using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.Services.ContentServer.Model;

namespace AppService.Services.ContentServer
{
    public interface IBaseContentServer
    {
        Task<Document> UploadDocumentAsync(Document document);

        Document DownloadDocument(string path);

        IEnumerable<Document> GetAllDocuments();
    }
}
