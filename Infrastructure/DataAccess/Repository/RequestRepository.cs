using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        public RequestRepository(AppDbContext context) : base(context)
        {

        }

        public Request MakeAction(int requestId, int statusId)
        {
            var request = GetById(requestId);
            request.DateModified = DateTime.Now;
            request.RequestStatusId = statusId;
            Save();
            return request;
        }

        public IEnumerable<RequestType> GetRequestTypes()
        {
            return _context.RequestTypes.ToList();
        }

        public IEnumerable<Request> GetAllRequests ()
        {
            var result = _context
                .Requests
                .Include(x => x.RequestType)
                .Include(x => x.RequestStatus);

            return result;
        }

        public IEnumerable<RequestStatus> GetRequestStatuses()
        {
            return _context.RequestStatuses.ToList();
        }

        public Request GetRequestById(int id)
        {
            var result = GetAllRequests().FirstOrDefault(x => x.Id == id);

            return result;
        }
    }
}
