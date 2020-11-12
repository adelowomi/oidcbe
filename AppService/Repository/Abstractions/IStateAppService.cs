using System;
using System.Collections.Generic;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    /// <summary>
    /// IStateAppService Interface
    /// </summary>
    public interface IStateAppService
    {
        /// <summary>
        /// Abstract Interface Method To Get All States And Convert To StateViewModel
        /// </summary>
        /// <returns></returns>
        IEnumerable<StateViewModel> GetAllStates();

        /// <summary>
        /// Abstract Interface Method To Get State By Its Id
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        StateViewModel GetStateByIts(int stateId);

        /// <summary>
        /// Abstract Interface Method To Get State By Its State Name
        /// </summary>
        /// <param name="stateName"></param>
        /// <returns></returns>
        StateViewModel GetStateByIts(string stateName);
    }
}
