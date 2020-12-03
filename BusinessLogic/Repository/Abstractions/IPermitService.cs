using System;
using System.Collections.Generic;
using Core.Model;

namespace BusinessLogic.Repository.Abstractions
{
    public interface IPermitService
    {
        Permit Create(Permit permit);

        IEnumerable<Permit> GetPermits();

        IEnumerable<Permit> GetPermitsBy(int userId);

        Permit GetPermitBy(int id);

        Permit UpdatePermit(Permit permit);

        IEnumerable<PermitType> GetPermitTypes();

        PermitType CreateNewPermitType(PermitType permitType);
    }
}
