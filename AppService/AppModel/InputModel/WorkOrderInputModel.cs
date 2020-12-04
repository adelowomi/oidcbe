using System;
using System.IO;
using AppService.Helpers;

namespace AppService.AppModel.InputModel
{
    public class WorkOrderInputModel
    {
        public int PlotId { get; set; }

        public int? AppUserId { get; set; }

        public string Document { get; set; }

        public string Description { get; set; }

        public int WorkOrderStatusId { get; set; }

        public string SaveDocument(AppSettings _settings)
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
                    imageFile.Flush();
                }

                Document = uniqueFileName;

                return profilePhotoPath;

            }
            catch (Exception e) { return null; }
        }

        public int WorkOrderTypeId { get; set; }
    }

    public enum WorkOrderStatusEnum
    {
        APPROVED = 1,
        PENDING,
        SUSPENDED,
        DECLINED
    }
}
