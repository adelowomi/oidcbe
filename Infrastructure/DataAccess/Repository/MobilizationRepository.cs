using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class MobilizationRepository : BaseRepository<Mobilization>, IMobilizationRepository
    {
        public MobilizationRepository(AppDbContext context) : base(context)
        {

        }

        public IEnumerable<Mobilization> All()
        {
            return _context.Mobilizations
                .Include(x => x.MobilizationStatus).ToList();
        }

        public Mobilization Approve(int id)
        {
            var mobililization = GetById(id);

            mobililization.MobilizationStatusId = (int)MobilizationStatusEnum.APPROVED;

            Save();

            return All().FirstOrDefault(x => x.Id == id);
        }

        public Mobilization Decline(int id)
        {
            var mobililization = GetById(id);

            mobililization.MobilizationStatusId = (int)MobilizationStatusEnum.DECLINED;

            Save();

            return All().FirstOrDefault(x => x.Id == id);
        }

        public Mobilization Suspend(int id)
        {
            var mobililization = GetById(id);

            mobililization.MobilizationStatusId = (int)MobilizationStatusEnum.SUSPENDED;

            Save();

            return All().FirstOrDefault(x => x.Id == id);
        }
    }
}
