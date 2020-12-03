using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IVehicleRepository
    {
        Vehicle CreateAndReturn(Vehicle permit);

        IEnumerable<Vehicle> GetAll();

        Vehicle GetById(int id);

        Vehicle Update(Vehicle entity);
    }
}
