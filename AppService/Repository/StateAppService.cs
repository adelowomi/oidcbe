using System;
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
    /// Concrete Implementation of @IStateAppService
    /// </summary>
    public class StateAppService : IStateAppService
    {
        protected IStateService _stateService;
        protected IMapper _mapper;

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="stateService"></param>
        /// <param name="mapper"></param>
        public StateAppService(IStateService stateService, IMapper mapper)
        {
            _mapper = mapper;
            _stateService = stateService;
        }

        /// <summary>
        /// Get All States and map the entity model to its respective view model
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StateViewModel> GetAllStates()
        {
            return _stateService.GetStates().Select(x => _mapper.Map<State, StateViewModel>(x));
        }

        /// <summary>
        /// Get State By State Id
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public StateViewModel GetStateByIts(int stateId)
        {
            return _mapper.Map<State, StateViewModel>(_stateService.GetState(stateId));
        }


        /// <summary>
        /// Get State By State Name
        /// </summary>
        /// <param name="stateName"></param>
        /// <returns></returns>
        public StateViewModel GetStateByIts(string stateName)
        {
            return _mapper.Map<State, StateViewModel>(_stateService.GetState(stateName));
        }
    }
}
