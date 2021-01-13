using System;
using System.Collections.Generic;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IJobAppService
    {
        ResponseViewModel GetAllJobs();

        ResponseViewModel GetJobBy(int id);

        ResponseViewModel CreateNewJob(JobInputModel job);

        ResponseViewModel UpdateJob(JobInputModel job);

        ResponseViewModel GetJobStatuses();

        ResponseViewModel GetJobTypes();
    }
}
