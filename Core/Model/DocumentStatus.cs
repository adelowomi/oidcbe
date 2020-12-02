using System;
namespace Core.Model
{
    public class DocumentStatus : BaseNameEntity
    {
      
    }

    public enum DocumentStatusEnum
    {
        PENDING  = 1,
        APPROVED,
        DECLINED
    }
}
