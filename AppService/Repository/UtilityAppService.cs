using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;

namespace AppService.Repository
{
    /// <summary>
    /// Concrete Implementation Of IUtilityAppService
    /// </summary>
    public class UtilityAppService : IUtilityAppService
    {
        private readonly IUtilityService _utiityService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="utilityService"></param>
        /// <param name="mapper"></param>
        public UtilityAppService(IUtilityService utilityService, IMapper mapper)
        {
            _utiityService = utilityService;
            _mapper = mapper;
        }

        /// <summary>
        /// Concrete Method To Get Gender By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GenderViewModel GenderById(int id)
        {
            return _mapper.Map<Gender, GenderViewModel>(_utiityService.GetGender(id));
        }

        /// <summary>
        /// Concrete Method To Get Gender By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GenderViewModel GenderByName(string name)
        {
            return _mapper.Map<Gender, GenderViewModel>(_utiityService.GetGender(name));
        }

        /// <summary>
        /// Concrete Method To Get All Payment Providers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentProviderViewModel> GetPaymentProviders()
        {
            return _utiityService.GetPaymentProviders().Select(_mapper.Map<PaymentProvider, PaymentProviderViewModel>);
        }
    }
}
