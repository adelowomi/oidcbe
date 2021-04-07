using System;
using System.Collections.Generic;
using System.Text;
using AppService.AppModel.ViewModel;
using Core.Model;

namespace AppService.Repository.Abstractions
{
    public interface IPaymentInstalmentAppService
    {
        /// <summary>
        /// Abstract Interface Method To Get All Installments In IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentInstalmentViewModel> GetInstalments();

        /// <summary>
        /// Abstract Interface Method To Get All Due Installments In IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentInstalmentViewModel> GetDueInstalments();
    }
}
