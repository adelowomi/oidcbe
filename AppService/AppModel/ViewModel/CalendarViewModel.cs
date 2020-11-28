using System;
namespace AppService.AppModel.ViewModel
{
    public class CalendarViewModel
    {
        public int Id { get; set; }

        //public PlotViewModel Plot { get; set; }

        public string Event { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
