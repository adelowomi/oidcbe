using System;
using System.IO;
using Microsoft.Extensions.Options;

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
        public static readonly string REQUEST_OTP_EMAIL_TEMPLATE_WEB = "RequestOTPWeb.html";
        public static readonly string REQUEST_RESET_PASSWORD_EMAIL_TEMPLATE_WEB = "ResetPasswordRequestWeb.html";
        public static readonly string REQUEST_RESET_PASSWORD_EMAIL_TEMPLATE = "ResetPasswordRequest.html";
        public static readonly string COMPLETE_RESET_PASSWORD_EMAIL_TEMPLATE = "ResetPasswordSuccessful.html";
        public static readonly string WELCOME_EMAIL_TEMPLATE = "Welcome.html";
        public static readonly string WELCOME_EMAIL_TEMPLATE_WEB = "WelcomeWeb.html";

        public static string RequestOtp(string platform)
        {
            return platform.ToLower() == "web" ? REQUEST_OTP_EMAIL_TEMPLATE_WEB : REQUEST_OTP_EMAIL_TEMPLATE;
        }

        public static string ResetPassword(string platform)
        {
            return platform == null ? REQUEST_RESET_PASSWORD_EMAIL_TEMPLATE : platform.ToLower() == "web" ? REQUEST_RESET_PASSWORD_EMAIL_TEMPLATE_WEB : REQUEST_RESET_PASSWORD_EMAIL_TEMPLATE;
        }

        public static string Welcome(string platform)
        {
            return platform.ToLower() == "web" ? WELCOME_EMAIL_TEMPLATE_WEB : WELCOME_EMAIL_TEMPLATE;
        }
    }

   
    /// <summary>
    /// Static Properties For Content Resource for the entire App.
    /// </summary>
    public class Res
    {
        public static readonly string YOUR_NEW_CONFIRMATION_CODE = "New Confirmation Code";
        public static readonly string REQUEST_PASSWORD_RESET = "Request For Password Reset";
        public static readonly string ACCOUNT_SETUP = "Account Setup";
        public static readonly string WEB_PLATFORM = "web";
        public static readonly string MOBILE_PLATFORM = "mobile";
        public static readonly string VENDOR = "Vendor";
        public static readonly string SUBSCRIBER = "Subscriber";
        public static readonly int ZERO = 0;

    }


    /// <summary>
    /// Content Placeholder Handler Static Properties
    /// </summary>
    public class Placeholder
    {
        public static readonly string EMAIL_PLACEHOLDER = "[email]";
        public static readonly string EMAIL = "{{email}}";
        public static readonly string MINUTES = "minutes";
        public static readonly string OTP = "{{otp}}";
        public static readonly string EXPIRES = "{{expire}}";
        public static readonly string NAME = "{{name}}";
    }
}
