using System;
namespace Core.Model
{
    public class Permit : BaseEntity
    {
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public int? VisitorId { get; set; }

        public Visitor Visitor { get; set; }

        public int? VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public int PermitTypeId { get; set; }

        public PermitType PermitType { get; set; }

        public int PermitStatusId { get; set; }

        public PermitStatus PermitStatus { get; set; }

        public string QRCodeCodeLink { get; set; }
    }

    public enum PermitTypeEnum
    {
        VISIT = 1,
        PARKING
    }

    public enum PermitStatusEnum
    {
        APPROVED = 1,
        PENDING,
        SUSPENDED,
        DECLINED
    }
}
