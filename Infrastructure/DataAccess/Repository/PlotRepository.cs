using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace Infrastructure.DataAccess.Repository
{
    public class PlotRepository : BaseRepository<Plot>, IPlotRepository
    {
        public PlotRepository(AppDbContext context) : base(context)
        {

        }

        public Plot GetPlotById(int id)
        {
            return GetAll().FirstOrDefault();
        }

        public IEnumerable<Plot> GetPlots()
        {
            return GetAll();
        }
    }
}
