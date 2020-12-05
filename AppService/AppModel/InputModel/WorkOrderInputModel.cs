using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AppService.Helpers;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;

namespace AppService.AppModel.InputModel
{
    public class WorkOrderInputModel
    {
        public int PlotId { get; set; }

        public int? AppUserId { get; set; }

        public IFormFile Documents { get; set; }

        public string Document { get; set; }

        public string Description { get; set; }

        public int WorkOrderStatusId { get; set; }
    }
}
