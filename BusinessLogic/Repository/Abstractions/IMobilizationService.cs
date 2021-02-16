using System;
using System.Collections.Generic;
using Core.Model;

namespace BusinessLogic.Repository.Abstractions
{
    public interface IMobilizationService
    {
        IEnumerable<Mobilization> GetAllMobilization();

        Mobilization CreateNew(Mobilization mobilization);

        Mobilization Update(Mobilization mobilization);

        Mobilization GetMobilizationBy(int id);

        IEnumerable<Mobilization> GetMobilizationByPlot(int id);

        IEnumerable<Mobilization> GetMobilizationByUser(int id);

        Mobilization Approve(int id);

        Mobilization Decline(int id);

        Mobilization Suspend(int id);
    }
}
