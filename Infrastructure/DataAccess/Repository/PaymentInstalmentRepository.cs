using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class PaymentInstalmentRepository : BaseRepository<PaymentInstalment> , IPaymentInstalmentRepository
    {
        public PaymentInstalmentRepository(AppDbContext context) : base(context)
        {

        }

        public IEnumerable<PaymentInstalment> GetInstalments()
        {
            var result = _context.PaymentInstalments
                .Include(x => x.Amount)
                .Include(x => x.PaymentDueDate)
                .Include(x => x.offerId);

            return result;
        }

        public IEnumerable<PaymentInstalment> GetDueInstalments()
        {
            var result = GetInstalments().Where(x => x.PaymentDueDate <= DateTime.Now);

            return result;
        }
    }
}
