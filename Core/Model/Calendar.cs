using System;
namespace Core.Model
{
    public class Calendar : NameBaseEntity
    {
        public int PlotId { get; set; }

        public Plot Plot { get; set; }
    }
}
