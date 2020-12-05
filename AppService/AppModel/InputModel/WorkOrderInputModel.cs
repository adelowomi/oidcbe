using System;
using System.IO;
using System.Threading.Tasks;
using AppService.Helpers;
using Firebase.Storage;

namespace AppService.AppModel.InputModel
{
    public class WorkOrderInputModel
    {
        public int PlotId { get; set; }

        public int? AppUserId { get; set; }

        public string Document { get; set; }

        public string Description { get; set; }

        public int WorkOrderStatusId { get; set; }

        public async Task<string> SaveDocumentAsync(AppSettings _settings)
        {
            try
            {
                var profilePhotoPath = string.Empty;

                var bytes = Convert.FromBase64String(Document);

                var uniqueFileName = Utility.GetUniqueFileName("WorkOrder" + ".jpg");

                var parentFolder = Path.Combine(_settings.UploadDrive, _settings.DriveName);

                if (!Directory.Exists(parentFolder))
                {
                    Directory.CreateDirectory(parentFolder);
                }

                profilePhotoPath = Path.Combine(parentFolder, uniqueFileName);

                using (var imageFile = new FileStream(profilePhotoPath, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);

                    // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
                    var task = new FirebaseStorage("oidc-1606928364813.appspot.com")
                        .Child("data")
                        .Child("random")
                        .Child("file.jpg")
                        .PutAsync(imageFile);

                    // Track progress of the upload
                    task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                    // await the task to wait until upload completes and get the download url
                    var downloadUrl = await task;

                    imageFile.Flush();
                }
                

                Document = uniqueFileName;

                return profilePhotoPath;

            }
            catch (Exception e) { return null; }
        }
    }
}
