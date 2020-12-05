using System;
namespace Core.Model
{
    public class Request : BaseEntity
    {
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public int RequestId { get; set; }

        public RequestType RequestType { get; set; }
    }
}
