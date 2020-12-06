using System;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AppService.Repository
{
    public class PermitAppService : ResponseViewModel, IPermitAppService
    {
        private readonly IPermitService _permitService;
        private readonly IMapper _mapper;
        protected readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVehicleRepository _vehicleRepository;

        public PermitAppService(IPermitService permitService,
            IMapper mapper, UserManager<AppUser> userManager,
            IVehicleRepository vehicleRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _permitService = permitService;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<ResponseViewModel> CreatePermit(PermitInputModel model)
        {
            var permitType = _permitService.GetPermitTypes().FirstOrDefault(x => x.Id == model.PermitTypeId);

            if(permitType == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PERMIT_TYPE, ResponseErrorCodeStatus.INVALID_PERMIT_TYPE);
            }

            var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());
                        
            var result = _mapper.Map<PermitInputModel, Permit>(model);

            if (model.PermitTypeId == (int)PermitTypeEnum.VISIT)
            {
                result.Visitor.AppUserId = user.Id;

                result.AppUserId = user.Id;

            } else {

                if(model.Vehicle == null)
                {
                    return NotFound(ResponseMessageViewModel.INVALID_VEHICLE_DETAILS, ResponseErrorCodeStatus.INVALID_VEHICLE_DETAILS);
                }

                var type =_vehicleRepository.GetVehicleTypes().FirstOrDefault(x => x.Id == model.Vehicle.VehicleTypeId);

                if(type == null)
                {
                    return NotFound(ResponseMessageViewModel.INVALID_VEHICLE_TYPE, ResponseErrorCodeStatus.INVALID_VEHICLE_TYPE);
                }

                result.Vehicle.AppUserId = user.Id;

                result.AppUserId = user.Id;
            }

            var savedResult =_permitService.Create(result);

            var mappedResult = _mapper.Map<Permit, PermitViewModel>(savedResult);

            return Ok(mappedResult);
        }

        public ResponseViewModel GetPermits()
        {
            var result = _permitService.GetPermits().Select(_mapper.Map<Permit, PermitViewModel>);

            return Ok(result);
        }

        public ResponseViewModel GetVehicleTypes()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseViewModel> GetPermitsBy()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseViewModel> GetPermitTypes()
        {
            throw new NotImplementedException();
        }
    }
}
