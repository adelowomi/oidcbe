using System;
namespace Core.Model
{
    public class Document : BaseEntity
    {
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public string Name { get; set; }

        public int DocumentTypeId { get; set; }

        public DocumentType DocumentType { get; set; }

        public int? PlotId { get; set; }

        public Plot Plot { get; set; }

    }

    enum DOCUMENTTYPE
    {
        SURVEY = 1,
        CONTRACT,
        DEED,
        JOB
    }
}
