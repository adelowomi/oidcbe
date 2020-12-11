using System;
namespace AppService.AppModel.ViewModel
{
    public class RequestViewModel
    {
        public int RequestId { get; set;  }

        public string RequestName { get; set; }

        public VendorViewModel AppUser { get; set; }

        public DateTime DateCreated { get; set; }

        public string RequestStatus { get; set; }

        public string Description { get; set; }

        public string RequestType { get; set; }

        public PlotViewModel Plot { get; set; }
    }
}
