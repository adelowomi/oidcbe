using System;
using System.Collections.Generic;
using System.Text;
using Core.Model;

namespace AppService.AppModel.ViewModel
{
    public class PaymentInstalmentViewModel
    {
        public double Amount { get; set; }

        public DateTime PaymentDueDate { get; set; }

        public int offerId { get; set; }
        public int Percentage { get; set; }

        public virtual Offer Offer { get; set; }
    }
}
