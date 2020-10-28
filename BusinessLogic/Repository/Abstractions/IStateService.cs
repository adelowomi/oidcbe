using System;
using System.Collections.Generic;
using Core.Model;

namespace BusinessLogic.Repository.Abstractions
{
    public interface IStateService
    {
        public State GetState(int stateId);

        public State GetState(string stateName);

        public IEnumerable<State> GetStates();
    }
}
