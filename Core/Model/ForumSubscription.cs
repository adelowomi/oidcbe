using System;
namespace Core.Model
{
    public class ForumSubscription : BaseEntity
    {
        public int ForumId { get; set; }

        public Forum Forum { get; set; }

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
