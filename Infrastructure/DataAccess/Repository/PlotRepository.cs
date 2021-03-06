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
        protected readonly IDocumentRepository _documentRepository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PlotRepository(AppDbContext context, IDocumentRepository documentRepository) : base(context)
        {
            _documentRepository = documentRepository;
        }

        public Plot CreatePlot(Plot plot)
        {
            var result = CreateAndReturn(plot);

            return GetPlots().FirstOrDefault(x => x.Id == result.Id);
        }

        public Plot EditPlot(Plot plot)
        {
            var result = Update(plot);

            return GetPlots().FirstOrDefault(x => x.Id == result.Id);
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
                .Include(x => x.AppUser)
                .Include(x => x.PlotType)
                .Include(x => x.PlotStatus)
                .Include(x => x.Calendars)
                .ToList();

            foreach(var plot in result)
            {
                var documents = _context.Documents
                    .Include(x => x.DocumentType)
                    .Include(x => x.Plot)
                    .Where(x => x.PlotId == plot.Id)
                    .ToList();

                plot.Documents = documents;
            }
            return result;
        }

        public IEnumerable<PlotType> GetPlotTypes()
        {
            return _context.PlotTypes.ToList();
        }

        public IEnumerable<Plot> GetSubscriberPlots(int id)
        {
            try
            {
                return GetPlots().Where(x => x.AppUserId == id);
            }
            catch(Exception e)
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
