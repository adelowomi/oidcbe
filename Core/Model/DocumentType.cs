using System;
namespace Core.Model
{
    public class DocumentType : BaseEntity
    {
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public string Name { get; set; }
    }
}
