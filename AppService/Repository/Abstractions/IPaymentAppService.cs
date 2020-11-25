using System;
using System.Collections.Generic;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IPaymentAppService
    {
        PaymentViewModel MakePayment(PaymentInputModel payment);

        IEnumerable<PaymentTypeViewModel> GetAllPaymentTypes();

        IEnumerable<PaymentMethodViewModel> GetAllPaymentMethods();

        IEnumerable<PaymentStatusViewModel> GetAllPaymentStatuses();

        IEnumerable<PaymentProviderViewModel> GetAllPaymentProviders();

        PaymentViewModel QueryPayment(int paymentId);
    }
}
