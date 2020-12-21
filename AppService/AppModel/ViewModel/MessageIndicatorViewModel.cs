using System;
using System.Collections.Generic;

namespace AppService.AppModel.ViewModel
{
    public class MessageIndicatorViewModel : BaseNameViewModel
    {
        public string Reference { get; set; }

        public bool IsEnded { get; set; }

        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}
