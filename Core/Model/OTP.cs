using System;
namespace Core.Model
{
    public class OTP : BaseEntity
    {
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public string Code { get; set; }

        public bool IsExpired { get; set; }

        public DateTime ExpiryDateTime { get; set; }

        public DateTime UsedDateTime { get; set; }
    }
}
