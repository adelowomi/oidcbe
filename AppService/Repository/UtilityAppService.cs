using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;

namespace AppService.Repository
{
    public class UtilityAppService : IUtilityAppService
    {
        private readonly IUtilityService _utiityService;
        private readonly IMapper _mapper;

        public UtilityAppService(IUtilityService utilityService, IMapper mapper)
        {
            _utiityService = utilityService;
            _mapper = mapper;
        }
        public GenderViewModel GenderById(int id)
        {
            return _mapper.Map<Gender, GenderViewModel>(_utiityService.GetGender(id));
        }

        public GenderViewModel GenderByName(string name)
        {
            return _mapper.Map<Gender, GenderViewModel>(_utiityService.GetGender(name));
        }

        public IEnumerable<PaymentProviderViewModel> GetPaymentProviders()
        {
            return _utiityService.GetPaymentProviders().Select(_mapper.Map<PaymentProvider, PaymentProviderViewModel>);
        }
    }
}
