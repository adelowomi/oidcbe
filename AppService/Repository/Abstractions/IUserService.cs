using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using System.Threading.Tasks;

namespace AppService.Repository.Abstractions
{
    public interface IUserService
    {
        Task<ResponseViewModel> AuthenticateAsync(LoginInputModel model);

        Task<ResponseViewModel> RegisterAsync(RegisterInputModel model);

        Task<ResponseViewModel> UpdateAsync(UserInputModel model);

        Task<ResponseViewModel> UpdateVendorAsync(VendorInputModel model);

        Task<ResponseViewModel> ResetPasswordAsync(string username, string platform);

        Task<ResponseViewModel> CompleteResetPasswordAsync(CompleteForgotPasswordInputModel model);

        Task<ResponseViewModel> ChangePasswordAsync(ChangePasswordInputModel model);

        UserInputModel GetUserById(int id);

        ResponseViewModel GetUserDetails();

        ResponseViewModel RequestForOTP(string emailAddress, string platform);

        ResponseViewModel ConfirmOTP(ConfirmOTPInputModel model);
    }
}