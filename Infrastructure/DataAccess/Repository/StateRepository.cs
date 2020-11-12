using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>
namespace Infrastructure.DataAccess.Repository
{
    /// <summary>
    /// Concrete Implementation Of IStateRepository
    /// </summary>
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public StateRepository(AppDbContext context) : base(context)
        {

        }

        /// <summary>
        /// Get State By Its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public State GetState(int id)
        {
            return GetById(id);
        }

        /// <summary>
        /// Get State By State Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public State GetState(string name)
        {
            return GetAll().SingleOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Get All States in IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<State> GetAllStates()
        {
            return GetAll();
        }
    }
}
