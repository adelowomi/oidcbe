using System;
using AppService.AppModel.ViewModel;

namespace AppService.Exceptions
{
    public class AppException
    {
        public AppException()
        {
        }
    }

    public class InvalidTokenCodeExcepton : Exception
    {
        public InvalidTokenCodeExcepton(string code) : base(ResponseMessageViewModel.INVALID_CONFIRMATION_CODE.Replace("[code]", code))
        {

        }
    }

    public class ExpiredTokenCodeException : Exception
    {
        public ExpiredTokenCodeException(string code) : base(ResponseMessageViewModel.EXPIRED_CONFIRMATION_CODE.Replace("[code]", code))
        {

        }
    }
}
