using System;
namespace Core.Model
{
    public class JobStatus : BaseNameEntity
    {
        
    }

    public enum JobStatusEnum
    {
        AVAILABLE = 1,
        UNAVAILABLE,
    }
}
