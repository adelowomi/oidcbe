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

        IEnumerable<Payment> GetAllPayments();

        IEnumerable<Payment> DuePayments();

        Payment LogPayment(int subscriptionId, int paymentType, int paymentMethod, int paymentProviderId, double amount);

        Payment ConfirmPayment(string trnxRef);

        IEnumerable<PaymentCycle> GetPaymentCycles();

        Payment ChangeStatus(int paymentId, int statusId);

        PaymentAllocation PaymentAllocation(PaymentAllocation payment);
    }
}
