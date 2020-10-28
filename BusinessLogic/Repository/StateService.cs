using System;
using System.Collections.Generic;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class StateService : IStateService
    {
        protected IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public State GetState(int stateId)
        {
            return _stateRepository.GetState(stateId);
        }

        public State GetState(string stateName)
        {
            return _stateRepository.GetState(stateName);
        }

        public IEnumerable<State> GetStates()
        {
            return _stateRepository.GetAllStates();
        }
    }
}
