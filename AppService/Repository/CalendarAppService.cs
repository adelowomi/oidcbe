using System;
using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AppService.Repository
{
    public class CalendarAppService : ICalendarAppService
    {
        private readonly ICalendarService _calendarService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly UserManager<AppUser> _userManager;

        public CalendarAppService(ICalendarService calendarService,
                                    UserManager<AppUser> userManager,
                                    IMapper mapper,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _calendarService = calendarService;
            _mapper = mapper;
        }

        public CalendarViewModel CalendarById(int id)
        {
            var result = _mapper.Map<Calendar, CalendarViewModel>(_calendarService.CalendarById(id));

            return result;
        }

        public IEnumerable<CalendarViewModel> CalendarByPlot(int plotId)
        {
            var result = _calendarService.CalendarByPlot(plotId).Select(_mapper.Map<Calendar, CalendarViewModel>);

            return result;
        }

        public IEnumerable<CalendarEventViewModel> CalendarEvents()
        {
            return _calendarService.CalendarEvents().Select(_mapper.Map<CalendarEvent, CalendarEventViewModel>);
        }

        public IEnumerable<CalendarViewModel> Calendars()
        {
            var result = _calendarService.Calendars().Select(_mapper.Map<Calendar, CalendarViewModel>);

            return result;
        }

        public CalendarViewModel NewCalendar(CalendarInputModel calendar)
        {
            var mappedResult = _mapper.Map<CalendarInputModel, Calendar>(calendar);

            var result = _calendarService.NewCalendar(mappedResult);

            return _mapper.Map<Calendar, CalendarViewModel>(result);
        }
    }
}
