using System;
using System.Collections.Generic;
using AppService.AppModel.InputModel;

namespace AppService.AppModel.ViewModel
{
    public interface IRequestAppService
    {
        IEnumerable<RequestViewModel> GetAllRequests();

        RequestViewModel GetRequestBy(int userId);

        RequestViewModel GetRequestBy(int userId, int requestId);

        RequestViewModel CreateRequest(RequestInputModel request);

        RequestViewModel UpdateRequest(RequestInputModel request);

        IEnumerable<RequestTypeViewModel> GetRequestTypes();
    }
}
