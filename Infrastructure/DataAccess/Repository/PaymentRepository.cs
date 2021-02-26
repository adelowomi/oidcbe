using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

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
            AllocatePlot(payment.SubscriptionId);
            return GetFullQueryPayment(payment.Id);
        }

        public IEnumerable<PaymentMethod> GetPaymentMethods()
        {
            return _context.PaymentMethods.ToList();
        }

        public void AllocatePlot(int subscriptionId)
        {
            Subscription subscription = _context.Subscriptions
                                        .Include(x => x.AppUser)
                                        .Include(x => x.Offer)
                                        .Include(x => x.Offer.Plot)
                                        .FirstOrDefault(x => x.Id == subscriptionId);

            subscription.Offer.Plot.AppUserId = subscription.AppUserId;

            Save();
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
                SubscriptionId = subscriptionId,
                TrnxRef = $"OD{Helpers.Helper.RandomNumber(10)}",
                PaymentStatusId = (int)PaymentStatusEnum.PENDING
            });
            return GetFullQueryPayment(result.Id);
        }

        public Payment GetFullQueryPayment(int paymentId)
        {
            return GetAllPayments().FirstOrDefault(x => x.Id == paymentId);
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            var result = _context.Payments
                .Include(x => x.PaymentProvider)
                .Include(x => x.PaymentMethod)
                .Include(x => x.PaymentType)
                .Include(x => x.PaymentStatus)
                .Include(x => x.Subscription)
                .Include(x => x.Subscription.Offer)
                .Include(x => x.Subscription.AppUser)
                .Include(x => x.Subscription.Offer.Plot)
                .Include(x => x.Subscription.Offer.Plot.PlotType)
                .Include(x => x.Subscription.Offer.Plot.PlotStatus)
                .Include(x => x.Subscription.SubscriptionStatus);
            return result;
        }

        public IEnumerable<PaymentCycle> GetPaymentCycles()
        {
            return _context.PaymentCycles.ToList();
        }
    }
}
