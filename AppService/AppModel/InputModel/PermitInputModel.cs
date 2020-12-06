using System;
namespace AppService.AppModel.InputModel
{
    public class PermitInputModel
    {
        public VisitorInputModel Visitor { get; set; }

        public VehicleInputModel Vehicle { get; set; }

        public int PermitTypeId { get; set; }
    }
}
