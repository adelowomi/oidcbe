using System;
namespace AppService.Services.ContentServer
{
    public class FileDocumentType
    {
        public string Extension { get; set; }

        public string MimeType { get; set; }

        public static FileDocumentType GetDocumentType(string type)
        {
            return new FileDocumentType { Extension = ".jpg", MimeType = type};
        }
    }

    public class MIMETYPE
    {
        public static string IMAGE => "image/jpeg";
    }
}
