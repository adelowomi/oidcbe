using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class PermitService : IPermitService
    {
        protected readonly IPermitRepository _permitRepository;
        protected readonly IVisitorRepository _visitorRepository;
        protected readonly IVehicleRepository _vehicleRepository;
       
        public PermitService(IPermitRepository permitRepository,
                             IVehicleRepository vehicleRepository,
                             IVisitorRepository visitorRepository)
        {
            _permitRepository = permitRepository;
            _visitorRepository = visitorRepository;
            _vehicleRepository = vehicleRepository;
        }

        public Permit Create(Permit permit)
        {
            if(permit.PermitTypeId == (int) PermitTypeEnum.VISIT)
            {
                var visitor = _visitorRepository.CreateAndReturn(permit.Visitor);
                permit.VisitorId = visitor.Id;
                permit.VehicleId = null;
                permit.Vehicle = null;
                var result = _permitRepository.CreateAndReturn(permit);
                result.PermitType = GetPermitTypes().FirstOrDefault(x => x.Id == result.PermitTypeId);
                return result;
            }

            var vehicle = _vehicleRepository.CreateAndReturn(permit.Vehicle);
            permit.VehicleId = vehicle.Id;
            permit.VisitorId = null;
            permit.Visitor = null;
            var query = _permitRepository.CreatePermit(permit);
            query.PermitType = GetPermitTypes().FirstOrDefault(x => x.Id == query.PermitTypeId);
            query.PermitStatus = GetPermitStatuses().FirstOrDefault(x => x.Id == query.PermitStatusId);

            return query;
        }

        public PermitType CreateNewPermitType(PermitType permitType)
        {
            var result = _permitRepository.CreatePermitType(permitType);

            return result;
        }

        public Permit GetPermitBy(int id)
        {
            return _permitRepository.GetById(id);
        }

        public IEnumerable<Permit> GetPermits()
        {
            return _permitRepository.All();
        }

        public IEnumerable<Permit> GetPermitsBy(int userId)
        {
            return _permitRepository.All().Where(x => x.AppUserId == userId);
        }

        public IEnumerable<PermitType> GetPermitTypes()
        {
            return _permitRepository.GetPermitTypes();
        }

        public Permit UpdatePermit(Permit permit)
        {
            return _permitRepository.Update(permit);
        }

        public IEnumerable<PermitStatus> GetPermitStatuses()
        {
            return _permitRepository.GetPermitStatuses();
        }
    }
}
