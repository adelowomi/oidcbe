using System;
using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;

namespace AppService.Repository.Abstractions
{
    public class MobilizationAppService : IMobilizationAppService
    {
        protected readonly IMobilizationService _mobilizationService;
        protected readonly IMapper _mapper;

        public MobilizationAppService(IMobilizationService mobilizationService, IMapper mapper)
        {
            _mobilizationService = mobilizationService;
            _mapper = mapper;
        }

        public MobilizationViewModel CreateNew(MobilizationInputModel model)
        {
            var mappedResult = _mobilizationService.CreateNew(_mapper.Map<MobilizationInputModel, Mobilization>(model));

            var result = _mapper.Map<Mobilization, MobilizationViewModel>(mappedResult);

            return result;
        }

        public IEnumerable<MobilizationViewModel> GetAll()
        {
            var result = _mobilizationService.GetAllMobilization().Select(_mapper.Map<Mobilization, MobilizationViewModel>);

            return result;
        }

        public IEnumerable<MobilizationViewModel> GetByPlot(int id)
        {
            var result = _mobilizationService
                            .GetMobilizationByPlot(id)
                                .Select(_mapper.Map<Mobilization, MobilizationViewModel>);

            return result;
        }

        public IEnumerable<MobilizationViewModel> GetByUser(int id)
        {
            var result = _mobilizationService
                           .GetMobilizationByUser(id)
                               .Select(_mapper.Map<Mobilization, MobilizationViewModel>);

            return result;
        }

        public MobilizationViewModel Update(MobilizationInputModel model)
        {
            var result = _mobilizationService.Update(_mapper.Map<MobilizationInputModel, Mobilization>(model));

            var mappedResult = _mapper.Map<Mobilization, MobilizationViewModel>(result);

            return mappedResult;
        }
    }
}
