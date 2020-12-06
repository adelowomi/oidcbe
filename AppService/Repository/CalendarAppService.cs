using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AppService.Repository
{
    public class CalendarAppService : ResponseViewModel, ICalendarAppService
    {
        private readonly ICalendarService _calendarService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly UserManager<AppUser> _userManager;
        protected readonly IPlotService _plotService;

        public CalendarAppService(ICalendarService calendarService,
                                    UserManager<AppUser> userManager,
                                    IMapper mapper,
                                    IPlotService plotService,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _calendarService = calendarService;
            _plotService = plotService;
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

        public ResponseViewModel NewCalendar(CalendarInputModel calendar)
        {
            var events = _calendarService.CalendarEvents().FirstOrDefault(x => x.Id == calendar.EventTypeId);

            if (events == null) {

                return NotFound(ResponseMessageViewModel.INVALID_CALENDAR_EVENT, ResponseErrorCodeStatus.INVALID_CALENDAR_EVENT);
            }

            var plot = _plotService.AllPlots().FirstOrDefault(x => x.Id == calendar.PlotId);

            if(plot == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PLOT, ResponseErrorCodeStatus.INVALID_PLOT);
            }

            var mappedResult = _mapper.Map<CalendarInputModel, Calendar>(calendar);

            var result = _calendarService.NewCalendar(mappedResult);

            return Ok(_mapper.Map<Calendar, CalendarViewModel>(result));
        }
    }
}
