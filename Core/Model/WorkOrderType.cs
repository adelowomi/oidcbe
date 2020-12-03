using System;
namespace Core.Model
{
    public class WorkOrderType : BaseNameEntity
    {
        
    }

    public enum WorkOrderTypeEnum
    {
        ARCHITECTURE_DRAWING = 1,
        CIVIL_DRAWING,
        SERVICE_DRAWING
    }
}
