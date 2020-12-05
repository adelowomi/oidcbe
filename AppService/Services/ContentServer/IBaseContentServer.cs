using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.Services.ContentServer.Model;

namespace AppService.Services.ContentServer
{
    public interface IBaseContentServer
    {
        Task<FileDocument> UploadDocumentAsync(FileDocument document);

        FileDocument DownloadDocument(string path);

        IEnumerable<FileDocument> GetAllDocuments();
    }
}
