using System;
using System.Collections.Generic;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public IEnumerable<PaymentMethod> GetAllPaymentMethods()
        {
            return _paymentRepository.GetPaymentMethods();
        }

        public IEnumerable<PaymentProvider> GetAllPaymentProviders()
        {
            return _paymentRepository.GetPaymentProviders();
        }

        public IEnumerable<PaymentStatus> GetAllPaymentStatuses()
        {
            return _paymentRepository.GetPaymentStatuses();
        }

        public IEnumerable<PaymentType> GetAllPaymentTypes()
        {
            return _paymentRepository.GetPaymentTypes();
        }

        public IEnumerable<Payment> GetPayments()
        {
            return _paymentRepository.GetAllPayments();
        }

        public Payment LogNewPayment(int subscriptionId, int paymentType, int paymentMethod, int paymentProviderId, double amount)
        {
            return _paymentRepository.LogPayment(subscriptionId, paymentType, paymentMethod, paymentProviderId, amount);
        }

        public Payment QueryPayment(string trnxRef)
        {
            return _paymentRepository.ConfirmPayment(trnxRef);
        }

        public IEnumerable<PaymentCycle> GetAvailablePaymentCycles()
        {
            return _paymentRepository.GetPaymentCycles();
        }

        public Payment EnableDisable(int paymentId, int statusId)
        {
            return _paymentRepository.ChangeStatus(paymentId, statusId);
        }

        public Payment ApprovePayment(int id)
        {
            return _paymentRepository.ChangeStatus(id, (int)PaymentStatusEnum.APPROVED);
        }

        public Payment DeclinePayment(int id)
        {
            return _paymentRepository.ChangeStatus(id, (int)PaymentStatusEnum.DECLINED);
        }

        public IEnumerable<Payment> GetDuePayments()
        {
            return _paymentRepository.DuePayments();
        }
    }
}
