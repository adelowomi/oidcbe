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
                .Include(x => x.Visitor);

            return result;
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
    }
}
