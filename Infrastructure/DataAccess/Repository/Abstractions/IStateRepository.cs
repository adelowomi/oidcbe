using System;
using System.Collections.Generic;
using Core.Model;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>
namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IStateRepository
    {
        /// <summary>
        /// Interface Abstract Method To Get All States Available 
        /// </summary>
        /// <returns></returns>
        IEnumerable<State> GetAllStates();

        /// <summary>
        /// Interface Abstract Method To State By Its Primary Key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        State GetState(int id);

        /// <summary>
        /// Interface Abstract Method To Get State By Its State Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        State GetState(string name);
    }
}
