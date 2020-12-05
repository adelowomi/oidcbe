using System;
using System.Collections.Generic;
using AppService.Services.ContentServer.Model;

namespace AppService.Services.ContentServer.Firebase
{
    public class FirebaseUpload : IBaseContentServer
    {
        public FirebaseUpload()
        {

        }

        public Document DownloadDocument(string path)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetAllDocuments()
        {
            throw new NotImplementedException();
        }

        public Document UploadDocument(Document document)
        {
            
        }
    }
}
