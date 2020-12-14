using System;
namespace Core.Model
{
    public class ForumMessageType : BaseNameEntity
    {

    }

    public enum ForumMessageTypeEnum
    {
        GENERAL = 1,
        ANNOUNCEMENT,
        NOTIFICATION,
        BULLETIN,
    }
}
