using System;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace Infrastructure.DataAccess.Repository
{
    public class MobilizationRepository : BaseRepository<Mobilization>, IMobilizationRepository
    {
        public MobilizationRepository(AppDbContext context) : base(context)
        {

        }
    }
}
