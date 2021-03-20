using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.InputModel;
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
    public class UtilityAppService : ResponseViewModel, IUtilityAppService
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

        public ResponseViewModel CreateNewAccount(AccountInputModel account)
        {
            var valid = _utiityService.GetAccounts().FirstOrDefault(x => x.Name == account.AccountName
                                                                            && x.Number == account.AccountNumber);

            if(valid == null) { return Failed(ResponseMessageViewModel.ACCOUNT_ALREADY_EXITS); }

            return Ok(_mapper.Map<Account, AccountViewModel>
                            (_utiityService.Create(_mapper.Map<AccountInputModel, Account>(account))));
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

        public ResponseViewModel GetAccounts()
        {
            var result = _utiityService.GetAccounts().Select(_mapper.Map<Account, AccountViewModel>);

            return Ok(result);
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
