using System;
using System.Collections.Generic;
using AppService.AppModel.InputModel;

namespace AppService.AppModel.ViewModel
{
    public class VendorViewModel
    {
        public string Title { get; set; }

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

        public int PaymentPercentage { get; set; }

        public int ProfileProgess
        {
            get {
                int totalProgress = 0;
                if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
                {
                    totalProgress += 10;
                }

                if (!string.IsNullOrEmpty(Gender))
                {
                    totalProgress += 10;
                }

                if (!string.IsNullOrEmpty(PhoneNumber))
                {
                    totalProgress += 10;
                }

                if (HasConfirmedEmail)
                {
                    totalProgress += 10;
                }

                if (HasUploadedProfilePhoto)
                {
                    totalProgress += 10;
                }

                if (HasUploadedDocument)
                {
                    totalProgress += 10;
                }

                if (!string.IsNullOrEmpty(Gender))
                {
                    totalProgress += 10;
                }

                return totalProgress;
            }
        }

        public string WebSiteUrl { get; set; }

        public string OfficeAddress { get; set; }

        public string RCNumber { get; set; }

        public string NameOfEntry { get; set; }

        public VendorNextOfKinInputModel NextOfKin { get; set; }

        public bool HasConfirmedEmail { get; set; }

        public bool HasUploadedDocument { get; set; }

        public bool HasUploadedProfilePhoto { get; set; }

        public IEnumerable<PlotViewModel> Plots { get; set; }

        public IEnumerable<PaymentViewModel> Payments { get; set; }

        public IEnumerable<RequestViewModel> Requests { get; set; }

        public int UserTypeId { get; set; }

        public string RepresentativeName { get; set; }

        public string RepresentativeEmail { get; set; }

        public string RepresentativePhoneNumber { get; set; }

        public int? DepartmentId { get; set; }
    }
}
