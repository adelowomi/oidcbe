using System;
using System.Collections.Generic;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class CalendarService : ICalendarService
    {
        private readonly ICalendarRepository _calendarRepository;

        public CalendarService(ICalendarRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }

        public Calendar CalendarById(int id)
        {
            return _calendarRepository.GetCalandarBy(id);
        }

        public IEnumerable<Calendar> CalendarByPlot(int plotId)
        {
            return _calendarRepository.GetCalendarsByPlotId(plotId);
        }

        public IEnumerable<Calendar> Calendars()
        {
            return _calendarRepository.GetAllCalendars();
        }

        public Calendar NewCalendar(Calendar calendar)
        {
            return _calendarRepository.CreateNewCalendar(calendar);
        }
    }
}
