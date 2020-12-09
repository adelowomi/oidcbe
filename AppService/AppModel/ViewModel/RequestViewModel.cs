using System;
namespace AppService.AppModel.ViewModel
{
    public class RequestViewModel
    {
        public string RequestName { get; set; }

        public DateTime DateCreated { get; set; }

        public string RequestStatus { get; set; }

        public string Description { get; set; }

        public string RequestType { get; set; }
    }
}
