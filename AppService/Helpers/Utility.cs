using System;
using System.IO;

namespace AppService.Helpers
{
    /// <summary>
    /// Utility Classes
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Method to Get Unique File Name
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName) + "_" + Guid.NewGuid().ToString().Substring(5, 5) + Path.GetExtension(fileName);
        }
    }


    /// <summary>
    ///  Static Properties For User Types
    /// </summary>
    public class UserType
    {
        public static readonly string SUPER_ADMIN = "SUPER ADMIN";
        public static readonly string ADMIN = "ADMIN";
        public static readonly string VENDOR = "VENDOR";
        public static readonly string SUBSCRIBER = "SUBSCRIBER";
    }

    /// <summary>
    /// Static Properties Placholder For Email Templates
    /// </summary>
    public class EmailTemplate
    {
        public static readonly string REQUEST_OTP_EMAIL_TEMPLATE = "RequestOTP.html";
    }

    /// <summary>
    /// Static Properties For Content Resource for the entire App.
    /// </summary>
    public class Res
    {
        public static readonly string YOUR_NEW_CONFIRMATION_CODE = "New Confirmation Code";
    }

    /// <summary>
    /// Content Placeholder Handler Static Properties
    /// </summary>
    public class Placeholder
    {
        public static readonly string EMAIL_PLACEHOLDER = "[email]";
        public static readonly string MINUTES = "minutes";
        public static readonly string OTP = "{{otp}}";
        public static readonly string EXPIRES = "{{expire}}";
    }
}
