using System;
namespace Core.Model
{
    public class ForumMessage : BaseEntity
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public string Description { get; set; }

        public int ForumId { get; set; }

        public Forum Forum { get; set; }
    }
}
