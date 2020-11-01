using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IPlotRepository
    {
        Plot GetPlotById(int id);

        IEnumerable<Plot> GetPlots();
    }
}
