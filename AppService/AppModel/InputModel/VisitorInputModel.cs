using System;
namespace AppService.AppModel.InputModel
{
    public class VisitorInputModel
    {
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public DateTime CheckInDateTime { get; set; }

        public DateTime CheckOutDateTime { get; set; }
    }
}
