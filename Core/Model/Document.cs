using System;
namespace Core.Model
{
    public class Document : BaseEntity
    {
        public string Name { get; set; }

        public int DocumentTypeId { get; set; }

        public DocumentType DocumentType { get; set; }

    }

    enum DOCUMENTTYPE
    {
        SURVEY = 1,
        CONTRACT,
        DEED
    }
}
