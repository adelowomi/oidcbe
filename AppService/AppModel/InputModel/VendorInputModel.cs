using System;
using System.IO;
using AppService.AppModel.ViewModel;
using AppService.Helpers;

namespace AppService.AppModel.InputModel
{
    public class VendorInputModel : VendorViewModel
    {
        public string ResidentialAddress { get; set; }

        public string MailingAddress { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int StateOfOriginId { get; set; }

        public VendorNextOfKin NextOfKin { get; set; }

        public string ProfilePhotoName { get; set; }

        public string Gender { get; set; }

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

        public bool IsProfilePhotoChanged { get; set; }

        public bool IsIdentityDocumentChanged { get; set; }
    }

    public class VendorNextOfKin
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public string PhoneNumer { get; set; }

        public string Address { get; set; }
    }
}
