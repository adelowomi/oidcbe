using System;
namespace AppService.AppModel.ViewModel
{
    public class MobilizationViewModel
    {
        public int Id { get; set; }

        public int PlotId { get; set; }

        public string LeadName { get; set; }

        public string LeadPhoneNumber { get; set; }

        public int NumberOfWorkers { get; set; }

        public string IdentityPath { get; set; }
    }
}
