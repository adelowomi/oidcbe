using System;
namespace Core.Model
{
    public class RequestStatus : BaseNameEntity
    {
        
    }

    public enum RequestStatusEnum
    {
        APPROVED = 1,
        PENDING,
        SUSPENDED,
        REJECTED
    }
}
