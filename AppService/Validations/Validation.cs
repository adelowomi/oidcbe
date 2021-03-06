using AppService.AppModel.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppService.Validations
{
    public class Validation
    {

    }
    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }
        public string Message { get; }

        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }
    public class ValidationResultModel
    {
        public object Data { get; }
        public string Message { get; }
        public List<ValidationError> Errors { get; }
        public string StatusCode { get; }
        public bool Status;

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            try
            {
                Message = Errors.First().Message;
                Errors = modelState.Keys
                                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                                .ToList();
                StatusCode = ResponseErrorCodeStatus.VALIDATION_ERROR;
            }
            catch(Exception e)
            {
                Message = "Validation Errors";
                Errors = modelState.Keys
                                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                                .ToList();
                StatusCode = ResponseErrorCodeStatus.VALIDATION_ERROR;
            }
        }
    }

    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState) : base(new ValidationResultModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }

    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
            }
        }
    }
}