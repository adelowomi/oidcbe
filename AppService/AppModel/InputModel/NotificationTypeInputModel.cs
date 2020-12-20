using System;
namespace AppService.AppModel.InputModel
{
    public class NotificationTypeInputModel
    {
        public int NotificationTypeId { get; set; }
    }
}

public enum NotificationTypeEnum
{
    MOBILE = 1,
    WEB
}
