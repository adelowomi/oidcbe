using System;
using System.ComponentModel.DataAnnotations;
using AppService.AppModel.ViewModel;

namespace AppService.AppModel.InputModel
{
    public class PlotInputModel 
    {
        [Required]
        public int PlotTypeId { get; set; }

        [Required]
        public string PlotName { get; set; }

        [Required]
        public string PlotAddresss { get; set; }

        [Required]
        public double PlotAcres { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Lattitude { get; set; }

        [Required]
        public double KilometerSquare { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}
