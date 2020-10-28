using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace Infrastructure.DataAccess.Repository
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(AppDbContext context) : base(context)
        {

        }

        public State GetState(int id)
        {
            return GetById(id);
        }

        public State GetState(string name)
        {
            return GetAll().SingleOrDefault(x => x.Name == name);
        }

        public IEnumerable<State> GetAllStates()
        {
            return GetAll();
        }
    }
}
