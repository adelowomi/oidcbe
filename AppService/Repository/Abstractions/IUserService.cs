using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Repository.Abstractions
{
    public interface IUserService
    {
        Task<ResponseViewModel> AuthenticateAsync(LoginInputModel model);

        Task<ResponseViewModel> RegisterAsync(RegisterInputModel model);

        Task<ResponseViewModel> UpdateAsync(UserInputModel model);

        Task<ResponseViewModel> UpdateVendorAsync(VendorInputModel model);

        Task<ResponseViewModel> ResetPasswordAsync(string username);

        Task<ResponseViewModel> CompleteResetPasswordAsync(CompleteForgotPasswordInputModel model);

        Task<ResponseViewModel> ChangePasswordAsync(ChangePasswordInputModel model);

        UserInputModel GetUserById(int id);

        Task<VendorViewModel> GetUserDetails();

        ResponseViewModel RequestForOTP(string emailAddress);
    }
}