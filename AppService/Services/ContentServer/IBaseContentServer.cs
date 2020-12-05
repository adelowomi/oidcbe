using System.Collections.Generic;
using AppService.Services.ContentServer.Model;

namespace AppService.Services.ContentServer
{
    public interface IBaseContentServer
    {
        Document UploadDocument(Document document);

        Document DownloadDocument(string path);

        IEnumerable<Document> GetAllDocuments();
    }
}
