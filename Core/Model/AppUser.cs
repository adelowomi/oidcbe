using System;
using Microsoft.AspNetCore.Identity;

namespace Core.Model
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int GenderId { get; set; }

        public Gender Gender { get; set; }

        public string ProfilePhoto { get; set; }

        public string Token { get; set; }

        public string OTP { get; set; }
    }
}
