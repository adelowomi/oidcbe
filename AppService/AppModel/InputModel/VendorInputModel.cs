using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using AppService.AppModel.ViewModel;
using AppService.Helpers;

namespace AppService.AppModel.InputModel
{
    public class VendorInputModel : VendorViewModel
    {
        [Required]
        public string ResidentialAddress { get; set; }

        [Required]
        public string MailingAddress { get; set; }

        [Required]
        public int StateOfOriginId { get; set; }

        public string ProfilePhoto { get; set; }

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
            catch (Exception e) { return null; }
        }

        [Required]
        public string IdentityDocument { get; set; }

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

        [Required]
        public bool IsProfilePhotoChanged { get; set; }

        [Required]
        public bool IsIdentityDocumentChanged { get; set; }

        public int UserTypeId { get; set; }

        [Required]
        public int IdentificationId { get; set; }

        [Required]
        public string OtpCode { get; set; }
    }

    public class VendorNextOfKinInputModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }

    public class VendorNextOfKinViewModel : VendorNextOfKinInputModel
    {
        
    }
}
