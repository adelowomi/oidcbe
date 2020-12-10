using System;
namespace AppService.AppModel.ViewModel
{
    public class PermitViewModel
    {
        public int AppUserId { get; set; }

        public int? VisitorId { get; set; }

        public VisitorViewModel Visitor { get; set; }

        public int? VehicleId { get; set; }

        public VehicleViewModel Vehicle { get; set; }

        public int PermitTypeId { get; set; }

        public PermitTypeVieModel PermitType { get; set; }

        public string Status { get; set; }
    }
}
