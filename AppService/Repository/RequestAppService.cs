using System;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AppService.Repository.Abstractions;
using AutoMapper;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AppService.Repository
{
    public class RequestAppService : ResponseViewModel, IRequestAppService
    {
        protected readonly IRequestRepository _requestRepository;
        protected readonly IMapper _mapper;
        protected readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestAppService(IRequestRepository requestRepository,
                                 IMapper mapper,
                                 UserManager<AppUser> userManager,
                                 IHttpContextAccessor httpContextAccessor)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public ResponseViewModel Approve(int requestId)
        {
            var request = _requestRepository.GetAllRequests().FirstOrDefault(x => x.Id == requestId);

            if(request == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_REQUEST, ResponseErrorCodeStatus.INVALID_REQUEST);
            }

            var result = _requestRepository.MakeAction(requestId, (int)RequestStatusEnum.APPROVED);

            return Ok(_mapper.Map<Request, RequestViewModel>(result));
        }

        public async Task<ResponseViewModel> CreateRequest(RequestInputModel request)
        {
            var query = _requestRepository.GetRequestTypes().FirstOrDefault(x => x.Id == request.RequestTypeId);

            if(query == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_REQUEST_TYPE, ResponseErrorCodeStatus.INVALID_REQUEST_TYPE);
            }

            var currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            var mappedResult = _mapper.Map<RequestInputModel, Request>(request);

            mappedResult.AppUserId = currentUser.Id;

            mappedResult.RequestStatusId = (int) RequestStatusEnum.PENDING;
            
            var result = _requestRepository.CreateAndReturn(mappedResult);

            result = _requestRepository.GetAllRequests().FirstOrDefault(x => x.Id == result.Id);
            
            return Ok(_mapper.Map<Request, RequestViewModel>(result));
        }

        public ResponseViewModel Decline(int requestId)
        {
            var request = _requestRepository.GetAllRequests().FirstOrDefault(x => x.Id == requestId);

            if (request == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_REQUEST, ResponseErrorCodeStatus.INVALID_REQUEST);
            }

            var result = _requestRepository.MakeAction(requestId, (int)RequestStatusEnum.REJECTED);

            return Ok(_mapper.Map<Request, RequestViewModel>(result));
        }

        public ResponseViewModel GetAllRequests()
        {
            var result = _requestRepository.GetAllRequests().Select(_mapper.Map<Request, RequestViewModel>);

            return Ok(result);
        }

        public async Task<ResponseViewModel> GetRequestBy()
        {
            var currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            return Ok(_mapper.Map<Request, RequestViewModel>(_requestRepository.GetAllRequests().FirstOrDefault(x => x.AppUserId == currentUser.Id)));
        }

        public ResponseViewModel GetRequestBy(int requestId)
        {
            return Ok(_mapper.Map<Request, RequestViewModel>(_requestRepository.GetRequestById(requestId)));
        }

        public ResponseViewModel GetRequestStatus()
        {
            var status = _requestRepository.GetRequestStatuses().Select(_mapper.Map<RequestStatus, RequestStatusViewModel>);

            return Ok(status);
        }

        public ResponseViewModel GetRequestTypes()
        {
            return Ok(_requestRepository.GetRequestTypes().Select(_mapper.Map<RequestType, RequestTypeViewModel>));
        }

        public ResponseViewModel Suspended(int requestId)
        {
            var request = _requestRepository.GetAllRequests().FirstOrDefault(x => x.Id == requestId);

            if (request == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_REQUEST, ResponseErrorCodeStatus.INVALID_REQUEST);
            }

            var result = _requestRepository.MakeAction(requestId, (int)RequestStatusEnum.SUSPENDED);

            return Ok(_mapper.Map<Request, RequestViewModel>(result));
        }

        public ResponseViewModel UpdateRequest(RequestInputModel request)
        {
            throw new NotImplementedException();
        }
    }
}
