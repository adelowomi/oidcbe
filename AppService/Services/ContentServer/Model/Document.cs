using System;
namespace AppService.Services.ContentServer.Model
{
    public class Document
    {
        public string Path { get; set; }

        public string File { get; set; }

        public DocumentType DocumentType { get; set; }
    }
}
