using System;
namespace Core.Model
{
    public class DocumentStatus : NameBaseEntity
    {
      
    }

    public enum DocumentStatusEnum
    {
        PENDING  = 1,
        APPROVED,
        DECLINED
    }
}
