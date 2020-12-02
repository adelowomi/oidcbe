using System;
namespace Core.Model
{
    public class Vehicle : BaseNameEntity
    {
        public string Make { get; set; }

        public string PlateNumber { get; set; }

        public DateTime CheckInDateTime { get; set; }

        public DateTime CheckOutDateTime { get; set; }

        public int VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
