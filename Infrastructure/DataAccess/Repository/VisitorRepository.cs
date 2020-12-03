using System;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace Infrastructure.DataAccess.Repository
{
    public class VisitorRepository : BaseRepository<Visitor>, IVisitorRepository
    {
        public VisitorRepository(AppDbContext context) : base(context)
        {

        }
    }
}
