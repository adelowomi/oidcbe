using System;
using System.Collections.Generic;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IStateAppService
    {
        IEnumerable<StateViewModel> GetAllStates();

        StateViewModel GetStateByIts(int stateId);

        StateViewModel GetStateByIts(string stateName);
    }
}
