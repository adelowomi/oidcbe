using System;
namespace AppService.AppModel.InputModel
{
    public class CalendarInputModel
    {
        public string Title { get; set; }

        public int Category { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
