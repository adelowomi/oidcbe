using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IVisitorRepository
    {
        Visitor CreateAndReturn(Visitor permit);

        IEnumerable<Visitor> GetAll();

        Visitor GetById(int id);

        Visitor Update(Visitor entity);
    }
}
