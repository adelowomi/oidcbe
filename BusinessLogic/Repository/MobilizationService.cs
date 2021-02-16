using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class MobilizationService : IMobilizationService
    {
        protected readonly IMobilizationRepository _mobilizationRepository;

        public MobilizationService(IMobilizationRepository mobilizationRepository)
        {
            _mobilizationRepository = mobilizationRepository;
        }

        public Mobilization Approve(int id)
        {
            return _mobilizationRepository.Approve(id);
        }

        public Mobilization CreateNew(Mobilization mobilization)
        {
            mobilization.MobilizationStatusId = (int) MobilizationStatusEnum.PENDING;
            return _mobilizationRepository.CreateAndReturn(mobilization);
        }

        public Mobilization Decline(int id)
        {
            return _mobilizationRepository.Decline(id);
        }

        public IEnumerable<Mobilization> GetAllMobilization()
        {
            return _mobilizationRepository.All();
        }

        public Mobilization GetMobilizationBy(int id)
        {
            return _mobilizationRepository.GetById(id);
        }

        public IEnumerable<Mobilization> GetMobilizationByPlot(int id)
        {
            return _mobilizationRepository.All().Where(x => x.PlotId == id);
        }

        public IEnumerable<Mobilization> GetMobilizationByUser(int id)
        {
            return _mobilizationRepository.All().Where(x => x.AppUserId == id);
        }

        public Mobilization Suspend(int id)
        {
            return _mobilizationRepository.Suspend(id);
        }

        public Mobilization Update(Mobilization mobilization)
        {
            return _mobilizationRepository.Update(mobilization);
        }
    }
}
