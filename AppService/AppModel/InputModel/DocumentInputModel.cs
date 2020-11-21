using System;
using System.IO;
using AppService.Helpers;

namespace AppService.AppModel.InputModel
{
    public class DocumentInputModel
    {
        public int UserId { get; set; }

        public int DocumentType { get; set; }

        public string Document { get; set; }

        public string GetDocumentType() => DocumentType == (int)DOCUMENTTYPE.SURVEY ? "Survey" : DocumentType == (int)DOCUMENTTYPE.CONTRACT ? "Contract" : "Deed";

        public string SaveDocument(AppSettings _settings)
        {
            try
            {
                var profilePhotoPath = string.Empty;

                var bytes = Convert.FromBase64String(Document);

                var uniqueFileName = Utility.GetUniqueFileName(GetDocumentType() + ".jpg");

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

    enum DOCUMENTTYPE
    {
        SURVEY = 1,
        CONTRACT,
        DEED
    }
}
