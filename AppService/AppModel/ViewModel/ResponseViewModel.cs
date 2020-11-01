﻿using System;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ApplicationService.ViewModel.ResponseViewModel"/> class.
        /// </summary>
        private ResponseViewModel()
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

        private ResponseViewModel(bool status, string message, object data, string statusCode)
        {
            Status = status;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }

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
            return new ResponseViewModel(true, message);
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


        /// <summary>
        ///  Ok that return this
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseViewModel Ok()
        {
            return new ResponseViewModel(true, ResponseMessageViewModel.SUCCESSFUL);
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
        public static readonly string OK = "00";
        public static readonly string FAIL = "99";
        public static readonly string ACCOUNT_ALREADY_EXIST = "03";
        public static readonly string INVALID_CREDENTIALS = "04";
        public static readonly string INVALID_GENDER = "05";
        public static readonly string INVALID_STATE = "06";
        public static readonly string INVALID_NEXT_OF_KIN_GENDER = "07";
    }
}





