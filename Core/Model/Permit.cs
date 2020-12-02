using System;
namespace Core.Model
{
    public class Permit : BaseEntity
    {
        public int PermitTypeId { get; set; }

        public PermitType PermitType { get; set; }
    }
}
