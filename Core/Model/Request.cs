using System;
namespace Core.Model
{
    public class Request : BaseNameEntity
    {
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public int RequestTypeId { get; set; }

        public string Description { get; set; }

        public int? PlotId { get; set; }

        public Plot Plot { get; set; }

        public RequestType RequestType { get; set; }

        public int? RequestStatusId { get; set; }

        public RequestStatus RequestStatus { get; set; }
    }
}
