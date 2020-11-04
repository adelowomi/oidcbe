using System;
using System.IO;

namespace AppService.Helpers
{
    public class Utility
    {
        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName) + "_" + Guid.NewGuid().ToString().Substring(5, 5) + Path.GetExtension(fileName);
        }
    }


    public class UserType
    {
        public static readonly string SUPER_ADMIN = "SUPER ADMIN";
        public static readonly string ADMIN = "ADMIN";
        public static readonly string VENDOR = "VENDOR";
        public static readonly string SUBSCRIBER = "SUBSCRIBER";
    }
}
