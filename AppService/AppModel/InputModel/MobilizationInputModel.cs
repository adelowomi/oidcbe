using System;
namespace AppService.AppModel.InputModel
{
    public class MobilizationInputModel
    {
        public int PlotId { get; set; }

        public virtual int? AppUserId { get; set; }

        public string LeadName { get; set; }

        public string LeadPhoneNumber { get; set; }

        public int NumberOfWorkers { get; set; }

        public string IdentityPath { get; set; }
    }
}
