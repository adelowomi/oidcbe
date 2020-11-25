using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IPaymentRepository
    {
        IEnumerable<PaymentType> GetPaymentTypes();

        IEnumerable<PaymentMethod> GetPaymentMethods();

        IEnumerable<PaymentStatus> GetPaymentStatuses();

        IEnumerable<PaymentProvider> GetPaymentProviders();

        Payment LogPayment(int subscriptionId, int paymentType, int paymentMethod, int paymentProviderId, double amount);

        Payment ConfirmPayment(int paymentId);
    }
}
