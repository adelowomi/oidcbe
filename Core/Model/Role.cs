using System;
using Microsoft.AspNetCore.Identity;

namespace Core.Model
{
    public class Role : IdentityRole<int>
    {
        
    }

    public enum RoleEnum
    {
        SUPER_ADMIN = 1,
        ADMIN = 2,
        VENDOR = 3,
        SUBSCRIBER
    }
}
