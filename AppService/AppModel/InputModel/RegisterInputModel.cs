using AppService.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace AppService.AppModel.InputModel
{
    public class RegisterInputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public UserTypeEnum UserType { get; set; }

        public string SaveProfilePhoto(AppSettings _settings)
        {
            return string.Empty;
            //    try
            //    {
            //        var profilePhotoPath = string.Empty;

            //        var bytes = Convert.FromBase64String(ProfilePhoto);

            //        var uniqueFileName = GetUniqueFileName(FirstName + "-" + LastName + ".jpg");

            //        var parentFolder = Path.Combine(_settings.UploadDrive, _settings.DriveName);

            //        if (!Directory.Exists(parentFolder))
            //        {
            //            Directory.CreateDirectory(parentFolder);
            //        }

            //        profilePhotoPath = Path.Combine(parentFolder, uniqueFileName);

            //        using (var imageFile = new FileStream(profilePhotoPath, FileMode.Create))
            //        {
            //            imageFile.Write(bytes, 0, bytes.Length);
            //            imageFile.Flush();
            //        }

            //        profilePhotoPath = uniqueFileName;

            //        return profilePhotoPath;

            //    }
            //    catch (Exception e) { return null; }
            //}

            //public string GetUniqueFileName(string fileName)
            //{
            //    fileName = Path.GetFileName(fileName);
            //    return Path.GetFileNameWithoutExtension(fileName) + "_" + Guid.NewGuid().ToString().Substring(5, 5) + Path.GetExtension(fileName);
            //}
        }
    }

    public enum UserTypeEnum
    {
        INDIVIDUAL = 1,
        CORPORATE
    }
}