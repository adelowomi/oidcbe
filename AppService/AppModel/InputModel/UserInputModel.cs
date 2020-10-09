using AppService.AppModel.ViewModel;
using AppService.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppService.AppModel.InputModel
{
    public class UserInputModel : UserViewModel
    {
        public bool IsProfilePhotoChanged { get; set; }

        public string SaveProfilePhoto(AppSettings _settings)
        {
            try
            {
                var profilePhotoPath = string.Empty;

                var bytes = Convert.FromBase64String(ProfilePhoto);

                var uniqueFileName = GetUniqueFileName(FirstName + "-" + LastName + ".jpg");

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

        public string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName) + "_" + Guid.NewGuid().ToString().Substring(5, 5) + Path.GetExtension(fileName);
        }

        public string Role { get; set; }
    }
}

