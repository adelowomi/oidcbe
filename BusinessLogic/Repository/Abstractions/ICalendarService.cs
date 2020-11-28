using System;
using System.Collections.Generic;
using Core.Model;

namespace BusinessLogic.Repository.Abstractions
{
    public interface ICalendarService
    {
        Calendar NewCalendar(Calendar calendar);

        IEnumerable<Calendar> Calendars();

        IEnumerable<Calendar> CalendarByPlot(int plotId);

        IEnumerable<CalendarEvent> CalendarEvents();

        Calendar CalendarById(int it);
    }
}
