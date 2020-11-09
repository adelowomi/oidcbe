using System;
namespace AppService.AppModel.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string NextOfKin { get; set; }

        public string NextOfKinPhoneNumber { get; set; }

        public string Gender { get; set; }

        public string Token { get; set; }

        public string PhotoUrl { get; set; }

        public string DocumentUrl { get; set; }

        public bool HasConfirmedEmail { get; set; }

        public bool HasUploadedDocument { get; set; }

        public bool HasUploadedProfilePhoto { get; set; }
    }
}
