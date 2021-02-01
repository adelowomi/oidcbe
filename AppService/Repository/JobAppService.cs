using System;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using AppService.Services.ContentServer;
using AppService.Services.ContentServer.Model;
using AutoMapper;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.Extensions.Options;

namespace AppService.Repository
{
    public class JobAppService : ResponseViewModel, IJobAppService
    {
        protected readonly IJobRepository _jobRepository;
        protected readonly IMapper _mapper;
        protected readonly AppSettings _settings;
        protected readonly IUserService _userService;

        public JobAppService(IJobRepository jobRepository, IMapper mapper, IOptions<AppSettings> options, IUserService userService)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
            _settings = options.Value;
            _userService = userService;
        }

        public async Task<ResponseViewModel> CreateNewJob(JobInputModel model)
        {
            //var jobStatus = _jobRepository.GetJobStatuses().FirstOrDefault(x => x.Id == model.JobStatusId);

            //if(jobStatus == null)
            //{
            //    return Failed(ResponseMessageViewModel.INVALID_JOB_STATUS, ResponseErrorCodeStatus.INVALID_JOB_STATUS);
            //}

            var jobType = _jobRepository.GetJobTypes().FirstOrDefault(x => x.Id == model.JobTypeId);

            if (jobType == null)
            {
                return Failed(ResponseMessageViewModel.INVALID_JOB_TYPE, ResponseErrorCodeStatus.INVALID_JOB_TYPE);
            }

            var mappedResult = _mapper.Map<JobInputModel, Job>(model);

            var user = _userService.GetCurrentLoggedOnUserAsync().Result;

            mappedResult.AppUserId = user.Id;

            FileDocument uploadResult = FileDocument.Create();

            try
            {
                uploadResult = await
                   BaseContentServer
                   .Build(ContentServerTypeEnum.FIREBASE, _settings)
                   .UploadDocumentAsync(FileDocument.Create(model.Document, "Job" , $"{user.GUID}", FileDocumentType.GetDocumentType(MIMETYPE.IMAGE)));

                mappedResult.Document = uploadResult.Path;
            }
            catch (Exception e)
            {
                return Failed(ResponseMessageViewModel.ERROR_UPLOADING_FILE, ResponseErrorCodeStatus.ERROR_UPLOADING_FILE);
            }

            var result = _mapper.Map<Job, JobViewModel>(_jobRepository.CreateJob(mappedResult));

            return Ok(result);
        }

        public Task<ResponseViewModel> CreateNewJobAsync(JobInputModel job)
        {
            throw new NotImplementedException();
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
