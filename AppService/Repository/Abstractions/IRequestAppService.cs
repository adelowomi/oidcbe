using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IRequestAppService
    {
        ResponseViewModel GetAllRequests();

        Task<ResponseViewModel> GetRequestBy();

        ResponseViewModel GetRequestBy(int requestId);

        Task<ResponseViewModel> CreateRequest(RequestInputModel request);

        ResponseViewModel UpdateRequest(RequestInputModel request);

        ResponseViewModel GetRequestTypes();
    }
}
