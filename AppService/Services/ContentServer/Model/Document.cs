using System;
namespace AppService.Services.ContentServer.Model
{
    public class Document
    {
        private string _Path { get; set; }

        private string _File { get; set; }

        private string _Name { get; set; }

        public DocumentType _DocumentType { get; set; }

        private Document ()
        {

        }

        private Document(string File) { this._File = File;  }

        private Document(string File, string Name) { this._File = File; this._Name = Name; }

        private Document(string File, string Name, string Path) { this._File = File; this._Name = Name; this._Path = Path; }

        private Document(string File, string Name, string Path, DocumentType type) { this._File = File; this._Path = Path; }

        public static Document Create() => new Document();

        public static Document Create(string File) => new Document(File);

        public static Document Create(string File, string Name) => new Document(File, Name);

        public static Document Create(string File, string Name, string Path) => new Document(File, Name, Path);

        public static Document Create(string File, string Name, string Path, DocumentType Type) => new Document(File, Name, Path, Type);

        public string Path => _Path;

        public string File => _File;

        public string Name => _Name;

        public DocumentType DocumentType => _DocumentType;

    }
}
