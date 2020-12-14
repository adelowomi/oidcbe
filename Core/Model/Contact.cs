using System;
namespace Core.Model
{
    public class Contact : BaseNameEntity
    {
        public int ContactId { get; set; }

        public ContactType ContactType { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
