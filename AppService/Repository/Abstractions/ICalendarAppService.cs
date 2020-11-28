using System;
using System.Collections.Generic;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface ICalendarAppService
    {
        CalendarViewModel NewCalendar(CalendarInputModel calendar);

        IEnumerable<CalendarViewModel> Calendars();

        IEnumerable<CalendarViewModel> CalendarByPlot(int plotId);

        IEnumerable<CalendarEventViewModel> CalendarEvents();

        CalendarViewModel CalendarById(int it);
    }
}
