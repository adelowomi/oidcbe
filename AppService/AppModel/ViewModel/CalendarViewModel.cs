using System;
namespace AppService.AppModel.ViewModel
{
    public class CalendarViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public string Event { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime Date { get; set; }

        public bool IsActive { get; set; }
    }
}
