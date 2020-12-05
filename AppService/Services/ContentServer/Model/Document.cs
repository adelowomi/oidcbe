using System;
namespace AppService.Services.ContentServer.Model
{
    public class Document
    {
        private Document ()
        {

        }

        private Document(string File) { this._File = File;  }

        private Document(string File, string Path) { this._File = File; this._Path = Path; }

        public static Document Create() => new Document();

        public static Document Create(string File) => new Document(File);

        public static Document Create(string File, string Path) => new Document(File, Path);

        private string _Path { get; set; }

        private string _File { get; set; }

        public string GetPath => _Path;

        public string GetFile => _File;

        public DocumentType DocumentType { get; set; }
    }
}
