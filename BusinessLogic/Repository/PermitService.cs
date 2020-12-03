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

        public PermitService(IPermitRepository permitRepository,
                             IVisitorRepository visitorRepository)
        {
            _permitRepository = permitRepository;
            _visitorRepository = visitorRepository;
        }

        public Permit Create(Permit permit)
        {
            var result = _permitRepository.CreateAndReturn(permit);

            return result;
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
            return _permitRepository.GetAll();
        }

        public IEnumerable<Permit> GetPermitsBy(int userId)
        {
            return _permitRepository.GetAll().Where(x => x.AppUserId == userId);
        }

        public IEnumerable<PermitType> GetPermitTypes()
        {
            return _permitRepository.GetPermitTypes();
        }

        public Permit UpdatePermit(Permit permit)
        {
            return _permitRepository.Update(permit);
        }
    }
}
