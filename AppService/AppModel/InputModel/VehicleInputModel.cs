using System;
namespace AppService.AppModel.InputModel
{
    public class VehicleInputModel
    {
        public string Make { get; set; }

        public string PlateNumber { get; set; }

        public DateTime CheckInDateTime { get; set; }

        public DateTime CheckOutDateTime { get; set; }

        public int VehicleTypeId { get; set; }
    }
}
