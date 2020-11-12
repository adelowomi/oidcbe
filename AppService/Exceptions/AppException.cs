using System;
using AppService.AppModel.ViewModel;

namespace AppService.Exceptions
{

    /// <summary>
    /// Application's Exception
    /// </summary>
    public class AppException : Exception
    {
        public AppException()
        {
        }
    }

    /// <summary>
    /// Invalid Token Code Exception
    /// This Exception Is Thrown When User's Email Doesn't Matched With Code Recieved
    /// </summary>
    public class InvalidTokenCodeExcepton : Exception
    {
        public InvalidTokenCodeExcepton(string code) : base(ResponseMessageViewModel.INVALID_CONFIRMATION_CODE.Replace("[code]", code))
        {

        }
    }

    /// <summary>
    /// Expired Token Code Exception
    /// This Exception Is Thrown When User's Code Has Expired
    /// </summary>
    public class ExpiredTokenCodeException : Exception
    {
        /// <summary>
        /// ExpiredTokenCodeException Constructor
        /// </summary>
        /// <param name="code"></param>
        public ExpiredTokenCodeException(string code) : base(ResponseMessageViewModel.EXPIRED_CONFIRMATION_CODE.Replace("[code]", code))
        {

        }
    }
}
