using System;
namespace Core.Model
{
    public class Mobilization : BaseNameEntity
    {
        public int PlotId { get; set; }

        public Plot Plot { get; set; }

        public string LeadName { get; set; }

        public string LeadPhoneNumber { get; set; }

        public int NumberOfWorkers { get; set; }

        public string IdentityPath { get; set; }
    }
}
