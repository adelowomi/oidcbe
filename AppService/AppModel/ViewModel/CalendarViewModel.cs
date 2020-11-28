using System;
namespace AppService.AppModel.ViewModel
{
    public class CalendarViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public string Event { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
