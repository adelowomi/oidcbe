using System;
namespace AppService.AppModel.ViewModel
{
    public class ContactViewModel : BaseViewModel
    {
        public string Telephone { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }
    }
}
