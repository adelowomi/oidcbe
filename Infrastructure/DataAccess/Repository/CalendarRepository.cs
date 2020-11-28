using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class CalendarRepository : BaseRepository<Calendar>, ICalendarRepository
    {
        public CalendarRepository(AppDbContext context) : base(context)
        {

        }

        public Calendar CreateNewCalendar(Calendar calendar)
        {
            var result = CreateAndReturn(calendar);

            return result;
        }

        public IEnumerable<Calendar> GetAllCalendars()
        {
            var result = _context
                .Calendars
                .Include(x => x.Plot);
            return result;
        }

        public Calendar GetCalandarBy(int it)
        {
            return GetAllCalendars().FirstOrDefault(x => x.Id == it);
        }

        public IEnumerable<Calendar> GetCalendarsByPlotId(int plotId)
        {
            return GetAllCalendars().Where(x => x.PlotId == plotId);
        }
    }
}
