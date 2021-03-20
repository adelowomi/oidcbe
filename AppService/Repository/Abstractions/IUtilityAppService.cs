using System;
using System.Collections.Generic;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IUtilityAppService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GenderViewModel GenderById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        GenderViewModel GenderByName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentProviderViewModel> GetPaymentProviders();

        /// <summary>
        /// Get List Of Accounts
        /// </summary>
        /// <returns></returns>
        ResponseViewModel GetAccounts();

        /// <summary>
        /// Create New Account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        ResponseViewModel CreateNewAccount(AccountInputModel account);
    }
}
