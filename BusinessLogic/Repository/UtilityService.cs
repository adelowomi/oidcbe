using System;
using System.Collections.Generic;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>

namespace BusinessLogic.Repository
{
    /// <summary>
    /// Concrete Implementation Of IUtilityService (Business Logic)
    /// </summary>
    public class UtilityService : IUtilityService
    {
        private readonly IUtilityRepository _utilityRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="utilityRepository"></param>
        public UtilityService(IUtilityRepository utilityRepository)
        {
            _utilityRepository = utilityRepository;
        }

        /// <summary>
        /// Get Gender By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Gender GetGender(int id)
        {
            return _utilityRepository.GetGenderById(id);
        }

        /// <summary>
        /// Get Gender By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Gender GetGender(string name)
        {
            return _utilityRepository.GetGenderByName(name);
        }

        /// <summary>
        /// Get All Payment Providers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentProvider> GetPaymentProviders()
        {
            return _utilityRepository.GetPaymentProviders();
        }
    }
}
