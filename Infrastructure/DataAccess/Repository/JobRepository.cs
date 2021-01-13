using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        protected readonly AppDbContext context;

        public JobRepository(AppDbContext context) : base(context)
        {
           
        }

        public Job CreateJob(Job job)
        {
            var result = CreateAndReturn(job);

            return GetById(result.Id);
        }

        public Job GetJobBy(int id)
        {
            return GetJobs().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Job> GetJobs()
        {
            var result = _context
                .Jobs
                .Include(x => x.JobStatus)
                .Include(x => x.AppUser)
                .Include(x => x.JobType)

                ;

            return result;
        }

        public IEnumerable<JobStatus> GetJobStatuses()
        {
            return _context.JobStatuses.ToList();
        }

        public IEnumerable<JobType> GetJobTypes()
        {
            return _context.JobTypes.ToList();
        }

        public Job UpdateJob(Job job)
        {
            var result = Update(job);

            return GetById(result.Id);
        }
    }
}
