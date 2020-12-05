using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.Services.ContentServer.Model;

namespace AppService.Services.ContentServer.Firebase
{
    public class DropBoxUpload : IBaseContentServer
    {
        public DropBoxUpload()
        {
        }

        public FileDocument DownloadDocument(string path)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileDocument> GetAllDocuments()
        {
            throw new NotImplementedException();
        }

        public Task<FileDocument> UploadDocumentAsync(FileDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
