using System;
namespace Core.Model
{
    public class Calendar : BaseEntity
    {
        public string Title { get; set; }

        public string Note { get; set; }

        public string Description { get; set; }

        public int CalendarEventId { get; set; }

        public CalendarEvent CalendarEvent { get; set; }

        public int PlotId { get; set; }

        public Plot Plot { get; set; }
    }
}
