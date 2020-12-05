using System;
namespace AppService.Services.ContentServer.Model
{
    public class Document
    {
        private string _Path { get; set; }

        private string _File { get; set; }

        public DocumentType _DocumentType { get; set; }

        private Document ()
        {

        }

        private Document(string File) { this._File = File;  }

        private Document(string File, string Path) { this._File = File; this._Path = Path; }

        private Document(string File, string Path, DocumentType type) { this._File = File; this._Path = Path; }

        public static Document Create() => new Document();

        public static Document Create(string File) => new Document(File);

        public static Document Create(string File, string Path) => new Document(File, Path);

        public static Document Create(string File, string Path, DocumentType type) => new Document(File, Path);

        public string Path => _Path;

        public string File => _File;

        public DocumentType DocumentType => _DocumentType;

    }
}
