using System;
using System.Collections.Generic;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IPaymentAppService
    {
        /// <summary>
        /// Make Payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        ResponseViewModel MakePayment(PaymentInputModel payment);

        /// <summary>
        /// Get All Payment Types
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentTypeViewModel> GetAllPaymentTypes();

        /// <summary>
        /// Get All Payment Methods
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentMethodViewModel> GetAllPaymentMethods();

        /// <summary>
        /// Get All Payment Statuses
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentStatusViewModel> GetAllPaymentStatuses();

        /// <summary>
        /// Get All Payment Providers
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentProviderViewModel> GetAllPaymentProviders();

        /// <summary>
        /// Query Payment
        /// </summary>
        /// <param name="trnxRef"></param>
        /// <returns></returns>
        ResponseViewModel QueryPayment(string trnxRef);

        /// <summary>
        /// Get Payment History
        /// </summary>
        /// <returns></returns>
        ResponseViewModel GetPaymentHistory();

        /// <summary>
        /// Get Payment Cycle
        /// </summary>
        /// <returns></returns>
        ResponseViewModel GetPaymentCycle();

        /// <summary>
        /// Get Payment By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseViewModel GetPaymentById(int id);

        /// <summary>
        /// Get All Payments
        /// </summary>
        /// <returns></returns>
        ResponseViewModel GetAllPayments();

        /// <summary>
        /// Get E
        /// </summary>
        /// <returns></returns>
        ResponseViewModel GetApprovedPayments();
    }
}
