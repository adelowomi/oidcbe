using System;
using System.Collections.Generic;

namespace AppService.AppModel.InputModel
{
    public class NotificationInputModel
    {
        public List<String> RegistrationIds { get; set; }

        public int NotificationTypeId { get; set; }
    }
}
