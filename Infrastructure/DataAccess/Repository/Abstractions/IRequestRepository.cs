using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IRequestRepository
    {
        Request GetRequestById(int id);

        IEnumerable<Request> GetAllRequests();

        Request CreateAndReturn(Request request);

        Request Update(Request request);

        IEnumerable<RequestType> GetRequestTypes();

        Request MakeAction(int requestId, int statusId);

        IEnumerable<RequestStatus> GetRequestStatuses();
    }
}
