using System;
using System.Collections.Generic;
using Core.Model;

namespace BusinessLogic.Repository.Abstractions
{
    public interface IPaymentService
    {
        IEnumerable<PaymentType> GetAllPaymentTypes();

        IEnumerable<PaymentMethod> GetAllPaymentMethods();

        IEnumerable<PaymentStatus> GetAllPaymentStatuses();

        IEnumerable<PaymentProvider> GetAllPaymentProviders();

        IEnumerable<Payment> GetPayments();

        Payment LogNewPayment(int subscriptionId, int paymentType, int paymentMethod, int paymentProviderId, double amount);

        Payment QueryPayment(string trnxRef);

        IEnumerable<PaymentCycle> GetAvailablePaymentCycles();

        IEnumerable<Payment> GetApprovedPayments();
    }
}
