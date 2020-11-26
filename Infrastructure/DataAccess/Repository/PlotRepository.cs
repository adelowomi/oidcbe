using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>
namespace Infrastructure.DataAccess.Repository
{
    /// <summary>
    /// Concrete Implementation Of IPlotRepository
    /// </summary>
    public class PlotRepository : BaseRepository<Plot>, IPlotRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PlotRepository(AppDbContext context) : base(context)
        {

        }

        public IEnumerable<Plot> GetAllAvailablePlots()
        {
            return GetPlots().Where(x => x.IsAvailable == true);
        }

        /// <summary>
        /// Get Plot By Its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Plot GetPlotById(int id)
        {
            return GetById(id);
        }

        /// <summary>
        /// Get All Plots In Enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Plot> GetPlots()
        {
            var result = _context.Plots
                .Include(x => x.PlotType)
                .Include(x => x.PlotStatus)
                .Include(x => x.Documents);
            return result;
        }

        public IEnumerable<Plot> GetSubscriberPlots(int id)
        {
            try
            {
                AppUser user = _context.Users.FirstOrDefault(x => x.Id == id);

                return user.Plots ?? Enumerable.Empty<Plot>();

            }catch(Exception e)
            {
                return Enumerable.Empty<Plot>();
            }
        }

        public IEnumerable<Plot> GetVendorPlots(int id)
        {
            try
            {
                AppUser user = _context.Users.FirstOrDefault(x => x.Id == id);

                return user.Plots ?? Enumerable.Empty<Plot>();
            }
            catch (Exception e)
            {
                return Enumerable.Empty<Plot>();
            }
        }

        public Plot PurchasePlot(int userId)
        {
            var plot = GetAllAvailablePlots().FirstOrDefault();
            plot.AppUserId = userId;
            plot.IsAvailable = false;
            plot.PlotStatusId = (int)PlotStatusEnum.PENDING;
            return plot;
        }
    }
}
