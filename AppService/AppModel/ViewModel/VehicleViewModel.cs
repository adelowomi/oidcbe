using System;
namespace AppService.AppModel.ViewModel
{
    public class VehicleViewModel
    {
        public string Make { get; set; }

        public string PlateNumber { get; set; }

        public DateTime CheckInDateTime { get; set; }

        public DateTime CheckOutDateTime { get; set; }

        public int VehicleTypeId { get; set; }

        public VehicleTypeViewModel VehicleType { get; set; }
    }

    public class VehicleTypeViewModel {

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
