using System;
namespace AppService.AppModel.ViewModel
{
    public class BaseViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
