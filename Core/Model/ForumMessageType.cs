using System;
namespace Core.Model
{
    public class ForumMessageType : BaseNameEntity
    {

    }

    public enum ForumMessageTypeEnum
    {
        ANNOUNCEMENT = 1,
        NOTIFICATION,
        GROUP,
        BULLETIN,
    }
}
