using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IRequestAppService
    {
        ResponseViewModel GetAllRequests();

        ResponseViewModel GetRequestBy(int userId);

        ResponseViewModel GetRequestBy(int userId, int requestId);

        Task<ResponseViewModel> CreateRequest(RequestInputModel request);

        ResponseViewModel UpdateRequest(RequestInputModel request);

        ResponseViewModel GetRequestTypes();
    }
}
