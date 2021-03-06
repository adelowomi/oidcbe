using System;
using System.Collections.Generic;
using System.Text;

namespace AppService.AppModel.ViewModel
{
    public class ResponseViewModel
    {

        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string StatusCode { get; set; }
        public object Errors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ApplicationService.ViewModel.ResponseViewModel"/> class.
        /// </summary>
        public ResponseViewModel()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ApplicationService.ViewModel.ResponseViewModel"/> class.
        /// </summary>
        /// <param name="status">If set to <c>true</c> status.</param>
        private ResponseViewModel(bool status)
        {
            Status = status;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ApplicationService.ViewModel.ResponseViewModel"/> class.
        /// </summary>
        /// <param name="status">If set to <c>true</c> status.</param>
        /// <param name="message">Message.</param>
        private ResponseViewModel(bool status, string message)
        {
            Status = status;
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ApplicationService.ViewModel.ResponseViewModel"/> class.
        /// </summary>
        /// <param name="status">If set to <c>true</c> status.</param>
        /// <param name="message">Message.</param>
        /// <param name="data">Data.</param>
        private ResponseViewModel(bool status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Initialize ResponseViewModel(bool status, string message, object data, string statusCode)
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        private ResponseViewModel(bool status, string message, object data, string statusCode)
        {
            Status = status;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ResponseViewModel Create()
        {
            return new ResponseViewModel();
        }

        /// <summary>
        /// Create the specified status.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="status">If set to <c>true</c> status.</param>
        public static ResponseViewModel Create(bool status)
        {
            return new ResponseViewModel(status);
        }

        /// <summary>
        /// Create the specified status and message.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="status">If set to <c>true</c> status.</param>
        /// <param name="message">Message.</param>
        public static ResponseViewModel Create(bool status, string message)
        {
            return new ResponseViewModel(status, message);
        }

        /// <summary>
        /// Create the specified status, message and data.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="status">If set to <c>true</c> status.</param>
        /// <param name="message">Message.</param>
        /// <param name="data">Data.</param>
        public static ResponseViewModel Create(bool status, string message, object data)
        {
            return new ResponseViewModel(status, message, data);
        }

        /// <summary>
        /// Adds the status code.
        /// </summary>
        /// <returns>The status code.</returns>
        /// <param name="statusCode">Status code.</param>

        public ResponseViewModel AddStatusCode(string statusCode)
        {
            StatusCode = statusCode;
            return this;
        }

        /// <summary>
        /// Adds the status message.
        /// </summary>
        /// <returns>The status message.</returns>
        /// <param name="message">Message.</param>
        public ResponseViewModel AddStatusMessage(string message)
        {
            this.Message = message;
            return this;
        }

        /// <summary>
        /// Error that return this
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseViewModel Error(string message)
        {
            return new ResponseViewModel(false, message);
        }

        /// <summary>
        /// Error that return this
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseViewModel Error(string message, string statusCode)
        {
            return new ResponseViewModel(false, message, null, statusCode);
        }

        /// <summary>
        ///  Ok that return this
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseViewModel Ok(string message)
        {
            return new ResponseViewModel(true, message, null, ResponseErrorCodeStatus.OK);
        }

        /// <summary>
        ///  Ok that return this
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseViewModel Ok(object data)
        {
            return new ResponseViewModel(true, ResponseMessageViewModel.SUCCESSFUL, data, ResponseErrorCodeStatus.OK);
        }

        public static ResponseViewModel NotFound(string message, string status)
        {
            return new ResponseViewModel(false, message, null, status);
        }
        /// <summary>
        ///  Ok that return this
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseViewModel Ok()
        {
            return new ResponseViewModel(true, ResponseMessageViewModel.SUCCESSFUL, null, ResponseErrorCodeStatus.OK);
        }

        /// <summary>
        ///  Failed that return this
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseViewModel Failed()
        {
            return new ResponseViewModel(false, ResponseMessageViewModel.UNSUCCESSFUL);
        }

        /// <summary>
        ///  Failed that return this
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseViewModel Failed(string message)
        {
            return new ResponseViewModel(false, message);
        }

        /// <summary>
        ///  Failed that return this
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseViewModel Failed(string message, string statusCode)
        {
            return new ResponseViewModel(false, message, null, statusCode);
        }


        /// <summary>
        /// Build this instance.
        /// </summary>
        /// <returns>The build.</returns>
        public ResponseViewModel Build()
        {
            return this;
        }

        public ResponseViewModel AddData(object data)
        {
            this.Data = data;
            return this;
        }
    }

    /// <summary>
    /// Response message view model.
    /// </summary>
    public static class ResponseStatusViewModel
    {
        public readonly static bool SUCCESS = true;
        public readonly static bool FAILURE;
    }

    /// <summary>
    /// Response message view model.
    /// </summary>
    public static class ResponseMessageViewModel
    {
        public static string OK => SUCCESSFUL;
        public static string SUCCESSFUL = "Successful";
        public static string UNSUCCESSFUL = "Unsuccessful";
        public static string ACCOUNT_ALREADY_EXITS = "Account already exits, please try again.";
        public static string INVALID_CREDENTIALS = "Invalid credentials";
        public static string AUTHENTICATION_SUCCESSFUL = "Authentication Successful";
        public static string PASSWORD_MISMATCH = "Password mistmatch, please try again later";
        public static string INVALID_GENDER = "Invalid gender selected please try again!";
        public static string INVALID_STATE = "Invalid State, please try again";
        public static string INVALID_NEXT_OF_KIN_GENDER = "Invalid Next Of Kin Gender, please try again";
        public static string UNKOWN_ERROR = "Unkown error, please try again!";
        public static string INVALID_CONFIRMATION_CODE = "The Confirmation Code '[code]' you entered is invalid, kindly enter the correct on and try again!";
        public static string EXPIRED_CONFIRMATION_CODE = "The Confirmation Code '[code]' you entered has expired. Do you want to request for a new one?";
        public static string CONFIRMATION_CODE_SENT = "You've successfully requested for a new Confirmation Code. Kindly check your email '[email]'";
        public static string PASSWORD_RESET_SUCCESSFUL = "Your request to reset your password was successful, kindly check your email";
        public static string UNABLE_TO_RESET_PASSWORD = "Unable to reset password, please try again!";
        public static string CHANGE_PASSWORD_FAILED = "Change Password Failed, Please try again!";
        public static string UNABLE_TO_CREATE = "Unable to create account";
        public static string EMAIL_NOT_CONFIRMED = "Email has not been confirmed, kindly confirm.";
        public static string INVALID_ORGANIZATION_TYPE = "Please select Organization Type and try again!";
        public static string INVALID_RC_NUMBER = "Please Enter Organization RC Number";
        public static string INVALID_OFFICE_ADDRESS = "Please enter Office Address";
        public static string INVALID_NAME_NAME_OF_ENTRY = "Please ennter name of entry and try again!";
        public static string INVALID_SUBSCRIPTION_ENTRY = "Invalid subscription, please try again!";
        public static string INVALID_PAYMENT_TYPE = "Invalid payment type, please try again!";
        public static string INVALID_PAYMENT_METHOD = "Invalid payment method";
        public static string INVALID_PAYMENT_PROVIDER = "Invalid payment provider";
        public static string NEXT_OF_KIN_ALREAD_EXITS = "Next of kin already exits";
        public static string INVALID_PLOT = "Invalid plot, please try again!";
        public static string INVALID_MOBILIZATION = "Invalid mobilization, try again";
        public static string INVALID_WORK_ORDER_TYPE = "Invalid work order, please try again!";
        public static string ERROR_UPLOADING_FILE = "Error uploading file, please try again!";
        public static string INVALID_REQUEST_TYPE = "Invalid Request Type";
        public static string INVALID_CALENDAR_EVENT = "Invalid, Calendar Event";
        public static string INVALID_PLOT_TYPE = "Invalid Plot Type";
        public static string INVALID_PERMIT_TYPE = "Invalid Permit Type";
        public static string INVALID_VEHICLE_TYPE = "Invalid Vehicle Type";
        public static string INVALID_VEHICLE_DETAILS = "Invalid Vehicle Details";
        public static string INVALID_DOCUMENT_TYPE = "Invalid Document Type";
        public static string INVALID_REQUEST = "Invalid Request Details, please try again";
        public static string SUBSCRIBER_NOT_EXITS = "Subscriber not exits";
        public static string INVALID_FORUM = "Invalid Forum, please try again!";
        public static string INVALID_FORUM_TYPE = "Invalid Forum, please try again!";
        public static string INVALID_STATUS = "Invalid Status";
        public static string INVALID_PROPOSAL = "Invalid Proposal";
        public static string INVALID_PLATFORM = "Invalid platform entered! Please try again!";
        public static string INVALID_JOB = "Invalid job detail";
        public static string INVALID_EMAIL_ADDRESS = "Invalid Email Address";
        public static string UNABLE_TO_CREATE_VENDOR = "Unable to create vendor, please try again!";
        public static string UNABLE_ASSIGN_ROLE_TO_VENDOR = "Unable to assign role to vendor, please try again!";
        public static string INVALID_JOB_STATUS = "Invalid job status, please select valid job status and try again!";
        public static string INVALID_JOB_TYPE = "Invalid job type, please select valid job type and try again!";
        public static string INVALID_DEPARTMENT = "Invalid Department, please try again";
        public static string INVALID_WORK_ORDER = "Invalid work order, please try again";
        public static string INVALID_PERMIT = "Invalid Permit, please try again";
        public static string EMAIL_ADDRESS_CONFIRMED = "Email address confirmed!";
        public static string UNABLE_TO_UPLOAD_RECEIPT = "Unable to upload receipt";
    }

    /// <summary>
    /// Response status code.
    /// </summary>
    public enum ResponseStatusCode 
    {
        OK = 00,
        FAIL = 01,
        ALREADY_EXIST = 03,
        NOT_AVAILABLE = 04,
        QUERY_SUCCESS = 05,
        INCORRECT_PHONENUMBER = 08,
        INVALID_MERCHANT_NAME,
        INVALID_EXTENSION_NAME,
        INVALID_CREDENTIALS
    }

    public static class ResponseErrorCodeStatus
    {
        //OK = GOOD(LOL, LMAO)
        public static readonly string OK = "00";
        
        //INVALID
        public static readonly string VALIDATION_ERROR = "02";
        public static readonly string ACCOUNT_ALREADY_EXIST = "03";
        public static readonly string INVALID_CREDENTIALS = "04";
        public static readonly string INVALID_GENDER = "05";
        public static readonly string INVALID_STATE = "06";
        public static readonly string INVALID_NEXT_OF_KIN_GENDER = "07";
        public static readonly string INVALID_CONFIRMATION_CODE = "08";
        
        //OTHERS
        public static readonly string EXPIRED_CONFIRMATION_CODE = "09";
        public static readonly string CONFIRMATION_CODE_SENT = "10";
        public static readonly string UNABLE_TO_RESET_PASSWORD = "11";
        public static readonly string CHANGE_PASSWORD_FAILED = "12";
        public static readonly string EMAIL_NOT_CONFIRMED = "13";
        public static readonly string INVALID_EMAIL_ADDRESS = "14";
        public static readonly string INVALID_ORGANIZATION_TYPE = "15";
        public static readonly string INVALID_RC_NUMBER = "16";
        public static readonly string INVALID_OFFICE_ADDRESS = "17";
        public static readonly string INVALID_NAME_NAME_OF_ENTRY = "18";
        public static readonly string INVALID_SUBSCRIPTION_ENTRY = "19";
        public static readonly string INVALID_PAYMENT_TYPE = "20";
        public static readonly string INVALID_PAYMENT_METHOD = "21";
        public static readonly string INVALID_PAYMENT_PROVIDER = "22";
        public static readonly string NEXT_OF_KIN_ALREAD_EXITS = "23";
        public static readonly string INVALID_PLOT = "24";
        public static readonly string INVALID_MOBILIZATION = "25";
        public static readonly string INVALID_WORK_ORDER_TYPE = "26";
        public static readonly string ERROR_UPLOADING_FILE = "27";
        public static readonly string INVALID_REQUEST_TYPE = "28";
        public static readonly string INVALID_CALENDAR_EVENT = "29";
        public static readonly string INVALID_PLOT_TYPE = "30";
        public static readonly string INVALID_PERMIT_TYPE = "31";
        public static readonly string INVALID_VEHICLE_TYPE = "32";
        public static readonly string INVALID_VEHICLE_DETAILS = "33";
        public static readonly string INVALID_DOCUMENT_TYPE = "34";
        public static readonly string INVALID_REQUEST = "35";
        public static readonly string SUBSCRIBER_NOT_EXITS = "36";
        public static readonly string INVALID_FORUM = "37";
        public static readonly string INVALID_FORUM_TYPE = "38";
        public static readonly string INVALID_STATUS = "39";
        public static readonly string INVALID_PROPOSAL = "40";
        public static readonly string INVALID_PLATFORM = "41";
        public static readonly string INVALID_JOB = "42";
        public static readonly string UNABLE_TO_CREATE_VENDOR = "44";
        public static readonly string UNABLE_ASSIGN_ROLE_TO_VENDOR = "45";
        public static readonly string INVALID_JOB_STATUS = "46";
        public static readonly string INVALID_JOB_TYPE = "47";
        public static readonly string INVALID_DEPARTMENT = "48";
        public static readonly string INVALID_WORK_ORDER = "49";
        public static readonly string INVALID_PERMIT = "50";
        public static readonly string EMAIL_ADDRESS_CONFIRMED = "51";
        public static readonly string UNABLE_TO_UPLOAD_RECEIPT = "52";

        //FAILURES
        public static readonly string FAIL = "91";
        public static readonly string UNKOWN_ERROR = "99";
    }
}





