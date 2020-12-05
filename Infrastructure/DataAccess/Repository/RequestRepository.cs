using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace Infrastructure.DataAccess.Repository
{
    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        public RequestRepository(AppDbContext context) : base(context)
        {

        }

        public IEnumerable<RequestType> GetRequestTypes()
        {
            return _context.RequestTypes.ToList();
        }
    }
}
