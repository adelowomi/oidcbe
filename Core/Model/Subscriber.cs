using System;
namespace Core.Model
{
    public class Subscriber : BaseEntity
    {
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }


    }
}
