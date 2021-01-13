using System;
using System.Linq;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace AppService.Repository
{
    public class JobAppService : ResponseViewModel, IJobAppService
    {
        protected readonly IJobRepository _jobRepository;
        protected readonly IMapper _mapper;

        public JobAppService(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public ResponseViewModel CreateNewJob(JobInputModel job)
        {
            var mappedResult = _mapper.Map<JobInputModel, Job>(job);

            job.JobStatusId = (int)JobStatusEnum.AVAILABLE;

            if(job.AppUserId == 0)
            {
                job.AppUserId = null;
            }

            var result = _mapper.Map<Job, JobViewModel>(_jobRepository.CreateJob(mappedResult));

            return Ok(result);
        }

        public ResponseViewModel GetAllJobs()
        {
            var result = _jobRepository.GetJobs().Select(_mapper.Map<Job, JobViewModel>);

            return Ok(result);
        }

        public ResponseViewModel GetJobBy(int id)
        {
            var result = _mapper.Map<Job, JobViewModel>(_jobRepository.GetJobBy(id));

            return Ok(result);
        }

        public ResponseViewModel GetJobStatuses()
        {
            var result = _jobRepository.GetJobStatuses().Select(_mapper.Map<JobStatus, JobStatusViewModel>);

            return Ok(result);
        }

        public ResponseViewModel GetJobTypes()
        {
            var result = _jobRepository.GetJobTypes().Select(_mapper.Map<JobType, JobTypeViewModel>);

            return Ok(result);
        }

        public ResponseViewModel UpdateJob(JobInputModel job)
        {
            var mappedResult = _jobRepository.UpdateJob(_mapper.Map<JobInputModel, Job>(job));

            var result = _mapper.Map<Job, JobViewModel>(mappedResult);

            return Ok(result);
        }
    }
}
