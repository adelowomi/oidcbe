using System;
using System.Linq;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;

namespace AppService.Repository
{
    public class DepartmentAppService : ResponseViewModel, IDepartmentAppService
    {
        protected readonly IUtilityService _utilityService;
        protected readonly IMapper _mapper;

        public DepartmentAppService(IUtilityService utilityService, IMapper mapper)
        {
            _utilityService = utilityService;
            _mapper = mapper;
        }

        public ResponseViewModel DepartmentBy(int id)
        {
            var result = _mapper.Map<Department, DepartmentViewModel>(_utilityService.DepartmentBy(id));

            return Ok(result);
        }

        public ResponseViewModel DepartmentBy(int id, string name)
        {
            var result = _mapper.Map<Department, DepartmentViewModel>(_utilityService.DepartmentBy(id, name));

            return Ok(result);
        }

        public ResponseViewModel Departments()
        {
            var results = _utilityService.Departments().Select(_mapper.Map<Department, DepartmentViewModel>);

            return Ok(results);
        }

        public ResponseViewModel GetUsersBy(int departmentId)
        {
            var results = _utilityService.GetUsersBy(departmentId).Select(_mapper.Map<AppUser, VendorViewModel>);

            return Ok(results);
        }
    }
}
