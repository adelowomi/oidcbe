using System;
namespace Core.Model
{
    public class NextOfKin : BaseEntity
    {
        public int AppUserId { get; set;}

        public AppUser AppUser { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Gender { get; set; }
    }
}
