using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IRequestRepository
    {
        Request GetById(int id);

        IEnumerable<Request> GetAll();

        Request Update(Request request);

        IEnumerable<RequestType> GetRequestTypes();
    }
}
