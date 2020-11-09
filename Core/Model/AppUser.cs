using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.Model
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string ProfilePhoto { get; set; }

        public string IdentityDocument { get; set; }

        public string Token { get; set; }

        public string OTP { get; set; }
       
        public string ResidentialAddress { get; set; }

        public string MailingAddress { get; set; }

        public int? StateOfOriginId { get; set; }

        public int? GenderId { get; set; }

        public Gender Gender { get; set; }

        public int? IdentificationId { get; set; }

        public Identification Identification { get; set; }

        public int? OrganizationTypeId { get; set; }

        public OrganizationType OrganizationType { get; set; }

        public State State { get; set; }

        public IEnumerable<Plot> Plots { get; set; }

        public IEnumerable<OTP> OTPs { get; set; }

        public IEnumerable<Subscription> Subscriptions { get; set; }

        public bool HasUploadedDocument { get; set; }

        public string EntryName { get; set; }

        public string RCNumber { get; set; }

        public string OfficeAddress { get; set; }

        public string WebsiteUrl { get; set; }
    }
}
