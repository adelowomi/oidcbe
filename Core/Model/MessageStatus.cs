using System;
namespace Core.Model
{
    public class MessageStatus : BaseNameEntity
    {
        
    }

    public enum MessageStatusEnum
    {
        PENDING = 1,
        DELIVERED ,
        SEEN
    }
}
