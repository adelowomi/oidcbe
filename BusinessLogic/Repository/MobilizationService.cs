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

        public Mobilization CreateNew(Mobilization mobilization)
        {
            return _mobilizationRepository.CreateAndReturn(mobilization);
        }

        public IEnumerable<Mobilization> GetAllMobilization()
        {
            return _mobilizationRepository.GetAll();
        }

        public Mobilization GetMobilizationBy(int id)
        {
            return _mobilizationRepository.GetById(id);
        }

        public IEnumerable<Mobilization> GetMobilizationByPlot(int id)
        {
            return _mobilizationRepository.GetAll().Where(x => x.PlotId == id);
        }

        public IEnumerable<Mobilization> GetMobilizationByUser(int id)
        {
            return _mobilizationRepository.GetAll().Where(x => x.AppUserId == id);
        }

        public Mobilization Update(Mobilization mobilization)
        {
            return _mobilizationRepository.Update(mobilization);
        }
    }
}
