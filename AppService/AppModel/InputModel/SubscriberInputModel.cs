using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using AppService.Helpers;

namespace AppService.AppModel.InputModel
{
    public class SubcriberIndividualInputModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int StateOfOriginId { get; set; }

        [Required]
        public string IdentityDocument { get; set; }

        public string ResidentialAddress { get; set; }

        public string Platform { get; set; }

        public string PhoneNumber { get; set; }

        public string MiddleName { get; set; }

        public string ProfilePhoto { get; set; }

        public VendorNextOfKinInputModel NextOfKin { get; set; }

        public string SaveProfilePhoto(AppSettings _settings)
        {
            try
            {
                var profilePhotoPath = string.Empty;

                var bytes = Convert.FromBase64String(ProfilePhoto);

                var uniqueFileName = Utility.GetUniqueFileName(FirstName + "-" + LastName + ".jpg");

                var parentFolder = Path.Combine(_settings.UploadDrive, _settings.DriveName);

                if (!Directory.Exists(parentFolder))
                {
                    Directory.CreateDirectory(parentFolder);
                }

                profilePhotoPath = Path.Combine(parentFolder, uniqueFileName);

                using (var imageFile = new FileStream(profilePhotoPath, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }

                profilePhotoPath = uniqueFileName;

                return profilePhotoPath;

            }
            catch (Exception e)
            {

                return null;
            }
        }

        public string SaveIdentityDocument(AppSettings _settings)
        {
            try
            {
                var profilePhotoPath = string.Empty;

                var bytes = Convert.FromBase64String(IdentityDocument);

                var uniqueFileName = Utility.GetUniqueFileName("Identity-Document-" + FirstName + "-" + LastName + ".jpg");

                var parentFolder = Path.Combine(_settings.UploadDrive, _settings.DriveName);

                if (!Directory.Exists(parentFolder))
                {
                    Directory.CreateDirectory(parentFolder);
                }

                profilePhotoPath = Path.Combine(parentFolder, uniqueFileName);

                using (var imageFile = new FileStream(profilePhotoPath, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }

                profilePhotoPath = uniqueFileName;

                return profilePhotoPath;

            }
            catch (Exception e) { return null; }
        }
    }


    public class SubscriberCorporateInputModel
    {
        [Required]
        public string NameOfEntry { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string OfficeAddress { get; set; }

        [Required]
        public string MailingAddress { get; set; }

        [Required]
        public int StateOfOriginId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Platform { get; set; }

        public string ProfilePhoto { get; set; }

        public string WebSiteUrl { get; set; }

        public string RCNumber { get; set; }

        public string SaveProfilePhoto(AppSettings _settings)
        {
            try
            {
                var profilePhotoPath = string.Empty;

                var bytes = Convert.FromBase64String(ProfilePhoto);

                var uniqueFileName = Utility.GetUniqueFileName(NameOfEntry + "-" + NameOfEntry + ".jpg");

                var parentFolder = Path.Combine(_settings.UploadDrive, _settings.DriveName);

                if (!Directory.Exists(parentFolder))
                {
                    Directory.CreateDirectory(parentFolder);
                }

                profilePhotoPath = Path.Combine(parentFolder, uniqueFileName);

                using (var imageFile = new FileStream(profilePhotoPath, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }

                profilePhotoPath = uniqueFileName;

                return profilePhotoPath;

            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
