using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class PaymentInstalmentService : IPaymentInstalmentService
    {
        private readonly IPaymentInstalmentRepository _paymentInstalmentRepository;

        public PaymentInstalmentService(IPaymentInstalmentRepository paymentInstalmentRepository)
        {
            _paymentInstalmentRepository = paymentInstalmentRepository;
        }
        public IEnumerable<PaymentInstalment> GetInstalments()
        {
            return _paymentInstalmentRepository.GetInstalments();
        }

        public IEnumerable<PaymentInstalment> GetDueInstalments()
        {
            return _paymentInstalmentRepository.GetDueInstalments();
        }
    }
}
