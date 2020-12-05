using System;
namespace AppService.AppModel.InputModel
{
    public class RequestInputModel
    {
        public string RequestName { get; set; }

        public int RequestTypeId { get; set; }

        public DateTime Date { get; set; }
    }
}
