using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.Model
{
    public class AppUser : IdentityUser<int>
    {
        public string Title { get; set; }

        public string GUID { get; set; }

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

        public IEnumerable<Document> Documents { get; set; }

        public bool HasUploadedDocument { get; set; }

        public bool HasUploadedProfilePhoto { get; set; }

        public string EntryName { get; set; }

        public string RCNumber { get; set; }

        public string OfficeAddress { get; set; }

        public string WebsiteUrl { get; set; }

        public bool IsExisting { get; set; }

        public NextOfKin NextOfKin { get; set; }

        public virtual AppUser Empty => new AppUser();

        public IEnumerable<ForumSubscription> ForumSubscriptions { get; set; }

        public string FireBaseToken { get; set; }

        public string RepresentativeName { get; set; }

        public string RepresentativeEmail { get; set; }

        public string RepresentativePhoneNumber { get; set; }

        public int? DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}