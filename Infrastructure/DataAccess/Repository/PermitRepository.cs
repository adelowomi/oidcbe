using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class PermitRepository : BaseRepository<Permit>, IPermitRepository
    {
        public PermitRepository(AppDbContext context) : base(context)
        {

        }

        public IEnumerable<Permit> All()
        {
            var result = _context.Permits
                .Include(x => x.PermitType)
                .Include(x => x.Vehicle)
                .Include(x => x.Visitor)
                .Include(x => x.PermitStatus);
            return result;
        }

        public Permit CreatePermit(Permit permit)
        {
            var result = CreateAndReturn(permit);

            return All().FirstOrDefault(x => x.Id == result.Id);
        }

        public PermitType CreatePermitType(PermitType permitType)
        {
            var result = _context.PermitTypes.Add(permitType);

            return result.Entity;
        }

        public IEnumerable<PermitType> GetPermitTypes()
        {
            return _context.PermitTypes.ToList();
        }

        public IEnumerable<PermitStatus> GetPermitStatuses ()
        {
            return _context.PermitStatuses.ToList();
        }

        public Permit Approve(int permitId)
        {
            var permit = GetById(permitId);

            permit.PermitStatusId = (int)PermitStatusEnum.APPROVED;

            Save();

            return permit;
        }

        public Permit Decline(int permitId)
        {
            var permit = GetById(permitId);

            permit.PermitStatusId = (int)PermitStatusEnum.DECLINED;

            Save();

            return permit;
        }

        public Permit Suspend(int permitId)
        {
            var permit = GetById(permitId);

            permit.PermitStatusId = (int)PermitStatusEnum.SUSPENDED;

            Save();

            return permit;
        }
    }
}
