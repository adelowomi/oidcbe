using System.Collections.Generic;
using Core.Model;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>
namespace BusinessLogic.Repository.Abstractions
{
    public interface IStateService
    {
        /// <summary>
        /// Abstract Interface Method To Get State By Id
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public State GetState(int stateId);

        /// <summary>
        /// Abstract Interface Method To Get State By State Name
        /// </summary>
        /// <param name="stateName"></param>
        /// <returns></returns>
        public State GetState(string stateName);

        /// <summary>
        /// Abstract Interface Method To Get States
        /// </summary>
        /// <returns></returns>
        public IEnumerable<State> GetStates();
    }
}
