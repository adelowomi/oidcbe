using System;
using System.Collections.Generic;

namespace AppService.AppModel.InputModel
{
    public class NotificationMessageInputModel
    {
        public int NotificationTypeId { get; set; }

        public int Message { get; set; }

        public List<string> Receivers { get; set; }
    }
}

public enum NotificationTypeEnum
{
    MOBILE = 1,
    WEB
}
