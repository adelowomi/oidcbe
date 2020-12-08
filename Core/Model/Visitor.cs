using System;
namespace Core.Model
{
    public class Visitor : BaseNameEntity
    {
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public DateTime CheckInDateTime { get; set; }

        public DateTime CheckOutDateTime { get; set; }
    }
}
