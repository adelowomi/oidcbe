﻿using System;
using System.Collections.Generic;

namespace AppService.AppModel.ViewModel
{
    public class PlotViewModel
    {
        public int PlotId { get; set; }

        public string PlotType { get; set; }

        public string PlotName { get; set; }

        public string PlotAddresss { get; set; }

        public double Acres { get; set; }

        public int VendorId { get; set; }

        public double Longitude { get; set; }

        public double Lattitude { get; set; }

        public double KilometerSquare { get; set; }

        public double Price { get; set; }

        public string Status { get; set; }

        public bool IsPaymentComplete { get; set; }

        public IEnumerable<DocumentViewModel> Documents { get; set; }

        public DateTime DatePurchased { get; set; }
    }
}
