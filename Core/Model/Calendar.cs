using System;
namespace Core.Model
{
    public class Calendar : NameBaseEntity
    {
        public int CalendarEventId { get; set; }

        public CalendarEvent CalendarEvent { get; set; }

        public int PlotId { get; set; }

        public Plot Plot { get; set; }
    }
}
