using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AppService.Helpers;
using AppService.Services.ContentServer.Model;
using Firebase.Storage;

namespace AppService.Services.ContentServer.Firebase
{
    public class FirebaseUpload : IBaseContentServer
    {
        private AppSettings _setting;

        public FirebaseUpload(AppSettings setting)
        {
            _setting = setting;
        }

        public FileDocument DownloadDocument(string path)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileDocument> GetAllDocuments()
        {
            throw new NotImplementedException();
        }

        public async Task<FileDocument> UploadDocumentAsync(FileDocument document)
        {
            try
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                CancellationToken token = cancellationTokenSource.Token;

                var profilePhotoPath = string.Empty;

                var bytes = Convert.FromBase64String(document.File);

                var uniqueFileName = Utility.GetUniqueFileName(document.FileNameWithExtension);

                var parentFolder = Path.Combine(_setting.UploadDrive, _setting.DriveName);

                if (!Directory.Exists(parentFolder))
                {
                    Directory.CreateDirectory(parentFolder);
                }

                profilePhotoPath = Path.Combine(parentFolder, uniqueFileName);

                using (var imageFile = new FileStream(profilePhotoPath, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);

                    imageFile.Flush();

                    var stream = new FileStream(profilePhotoPath, FileMode.Open);

                    var task = new FirebaseStorage(_setting.FireBaseBucket)
                        .Child("oidc")
                        .Child(document.Path)
                        .Child(document.FileNameWithExtension)
                        .PutAsync(stream, token, document.DocumentType.MimeType);

                    task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                    var result = await task;

                    return FileDocument.Create(null, document.Name, result, document.DocumentType);
                }
            }
            catch (Exception e) { return null; }
        }
    }
}
