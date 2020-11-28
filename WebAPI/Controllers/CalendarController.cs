using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using AutoMapper;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebAPI.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {

        private readonly ICalendarAppService _calendarAppService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly AppSettings _settings;


        public CalendarController(ICalendarAppService calendarAppService,
                                    UserManager<AppUser> userManager,
                                    IHttpContextAccessor httpContextAccessor,
                                    IMapper mapper, IOptions<AppSettings> options)
        {
            _calendarAppService = calendarAppService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _settings = options.Value;
        }

        /// <summary>
        ///  This method returns the raw file of an image, thereby mimicking access over web
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/calendar")]
        public IActionResult NewCalendar([FromBody] CalendarInputModel model)
        {
            return Ok(ResponseViewModel.Ok(_calendarAppService.NewCalendar(model)));
        }

        [HttpGet]
        [Route("api/calendar/plot/{id}")]
        public IActionResult GetCalendarBy(int plotId)
        {
            return Ok(ResponseViewModel.Ok(_calendarAppService.CalendarByPlot(plotId))) ;
        }

        [HttpGet]
        [Route("api/calendar/{id}")]
        public IActionResult GetCalendar(int id)
        {
            return Ok(ResponseViewModel.Ok(_calendarAppService.CalendarById(id)));
        }

        [HttpGet]
        [Route("api/calendar/alls")]
        public IActionResult GetAllCalendar()
        {
            return Ok(ResponseViewModel.Ok(_calendarAppService.Calendars()));
        }


        [HttpGet]
        [Route("api/calendar/events")]
        public IActionResult CalendarEvents()
        {
            return Ok(ResponseViewModel.Ok(_calendarAppService.CalendarEvents()));
        }
    }
}
