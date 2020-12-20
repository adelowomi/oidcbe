using System;
using System.Collections.Generic;
using FCM.Net;

namespace AppService.AppModel.InputModel
{
    public class NotificationInputModel
    {
        public Notification Notification { get; set; }

        public List<string> RegistrationIds { get; set; }

        public int NotificationTypeId { get; set; }
    }
}
