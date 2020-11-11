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
    /// Concrete Implementation Of IStateService
    /// </summary> 
    public class StateService : IStateService
    {
        protected IStateRepository _stateRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stateRepository"></param>
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        /// <summary>
        /// Get State By Id Implementation Method
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public State GetState(int stateId)
        {
            return _stateRepository.GetState(stateId);
        }

        /// <summary>
        /// Get State By Name Implementation Method
        /// </summary>
        /// <param name="stateName"></param>
        /// <returns></returns>
        public State GetState(string stateName)
        {
            return _stateRepository.GetState(stateName);
        }

        /// <summary>
        /// Get All States Implementation Method
        /// </summary>
        /// <returns></returns>
        public IEnumerable<State> GetStates()
        {
            return _stateRepository.GetAllStates();
        }
    }
}
