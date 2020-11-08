using System;
using AppService.AppModel.InputModel;

namespace AppService.AppModel.ViewModel
{
    public class VendorViewModel
    {
        public int UserId { get; set; }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string ResidentialAddress { get; set; }

        public string MailingAddress { get; set; }

        public string Email { get; set; }

        public string PhotoUrl { get; set; }

        public string DocumentUrl { get; set; }

        public int ProfileProgess { get; set; }

        public string WebSiteUrl { get; set; }

        public string OfficeAddress { get; set; }

        public string RCNumber { get; set; }

        public string NameOfEntry { get; set; }

        public VendorNextOfKinInputModel NextOfKin { get; set; }
    }
}
