using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IStateRepository
    {
        IEnumerable<State> GetAllStates();

        State GetState(int id);

        State GetState(string name);
    }
}
