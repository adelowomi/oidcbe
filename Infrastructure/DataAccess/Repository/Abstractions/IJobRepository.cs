using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IJobRepository
    {
        Job CreateJob(Job job);

        Job UpdateJob(Job job);

        Job GetJobBy(int id);

        IEnumerable<Job> GetJobs();
    }
}
