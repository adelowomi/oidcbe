using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface ICalendarRepository
    {
        Calendar CreateNewCalendar(Calendar calendar);

        IEnumerable<Calendar> GetAllCalendars();

        IEnumerable<Calendar> GetCalendarsByPlotId(int plotId);

        IEnumerable<CalendarEvent> GetEvents();

        Calendar GetCalandarBy(int it);
    }
}
