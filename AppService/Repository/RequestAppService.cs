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

            var result = _requestRepository.CreateAndReturn(mappedResult);

            
            return Ok(_mapper.Map<Request, RequestViewModel>(result));
        }

        public ResponseViewModel GetAllRequests()
        {
            var result = _requestRepository.GetAll().Select(_mapper.Map<Request, RequestViewModel>);

            return Ok(result);
        }

        public async Task<ResponseViewModel> GetRequestBy()
        {
            var currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            return Ok(_mapper.Map<Request, RequestViewModel>(_requestRepository.GetAll().FirstOrDefault(x => x.AppUserId == currentUser.Id)));
        }

        public ResponseViewModel GetRequestBy(int requestId)
        {
            return Ok(_mapper.Map<Request, RequestViewModel>(_requestRepository.GetById(requestId)));
        }

        public ResponseViewModel GetRequestTypes()
        {
            return Ok(_requestRepository.GetRequestTypes().Select(_mapper.Map<RequestType, RequestTypeViewModel>));
        }

        public ResponseViewModel UpdateRequest(RequestInputModel request)
        {
            throw new NotImplementedException();
        }
    }
}
