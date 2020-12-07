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
    }
}
