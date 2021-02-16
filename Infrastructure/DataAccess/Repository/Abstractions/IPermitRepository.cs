using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IPermitRepository
    {
        Permit CreateAndReturn(Permit permit);

        IEnumerable<Permit> All();

        Permit GetById(int id);

        Permit Update(Permit entity);

        PermitType CreatePermitType(PermitType permitType);

        IEnumerable<PermitType> GetPermitTypes();

        IEnumerable<PermitStatus> GetPermitStatuses();

        Permit CreatePermit(Permit permit);

        Permit Approve(int permitId);

        Permit Decline(int permitId);

        Permit Suspend(int permitId);
    }
}
