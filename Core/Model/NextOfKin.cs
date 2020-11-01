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

        public string Address { get; set; }

        public int? GenderId { get; set; }

        public Gender Gender { get; set; }
    }
}
