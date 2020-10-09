using System;
namespace Core.Model
{
    public class Post : BaseEntity
    {
        public string Comment { get; set; }

        public int PostTypeId { get; set; }

        public PostType PostType { get; set; }
    }
}
