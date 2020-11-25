using System;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IPaymentAppService
    {
        PaymentViewModel MakePayment(PaymentInputModel payment);
    }
}
