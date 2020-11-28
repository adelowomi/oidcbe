using System;
namespace AppService.AppModel.InputModel
{
    public class CalendarInputModel
    {
        public string Title { get; set; }

        public string Note { get; set; }

        public int PlotId { get; set; }

        public int EventTypeId { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
