using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace Infrastructure.DataAccess.Repository
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public Payment ConfirmPayment(string trnxRef)
        {
            var payment = GetAll().FirstOrDefault(x => x.TrnxRef == trnxRef);
            payment.PaymentStatusId = (int)PaymentStatusEnum.APPROVED;
            Update(payment);
            return payment;
        }

        public IEnumerable<PaymentMethod> GetPaymentMethods()
        {
            return _context.PaymentMethods.ToList();
        }

        public IEnumerable<PaymentProvider> GetPaymentProviders()
        {
            return _context.PaymentProviders.ToList();
        }

        public IEnumerable<PaymentStatus> GetPaymentStatuses()
        {
            return _context.PaymentStatuses.ToList();
        }

        public IEnumerable<PaymentType> GetPaymentTypes()
        {
            return _context.PaymentTypes.ToList();
        }

        public Payment LogPayment(int subscriptionId, int paymentType, int paymentMethod, int paymentProviderId, double amount)
        {
            var result =  CreateAndReturn(new Payment {
                PaymentMethodId = paymentMethod,
                PaymentTypeId = paymentType,
                PaymentProviderId = paymentProviderId,
                Amount = amount,
                subscriptionId = subscriptionId,
                TrnxRef = $"OD{Helpers.Helper.RandomNumber(10)}",
                PaymentStatusId = (int)PaymentStatusEnum.PENDING
            });

            return result;
        }
    }
}
