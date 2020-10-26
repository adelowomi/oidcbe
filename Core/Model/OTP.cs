using System;
namespace Core.Model
{
    public class OTP : BaseEntity
    {
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public string Code { get; set; }
    }
}
