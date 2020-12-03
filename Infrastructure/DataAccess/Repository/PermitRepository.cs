using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace Infrastructure.DataAccess.Repository
{
    public class PermitRepository : BaseRepository<Permit>, IPermitRepository
    {
        public PermitRepository(AppDbContext context) : base(context)
        {

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
