using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using Core.Model;
using System.Threading.Tasks;

namespace AppService.Repository.Abstractions
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseViewModel> AuthenticateAsync(LoginInputModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseViewModel> RegisterAsync(RegisterInputModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseViewModel> UpdateAsync(UserInputModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseViewModel> UpdateVendorAsync(VendorInputModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        Task<ResponseViewModel> ResetPasswordAsync(string username, string platform);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseViewModel> CompleteResetPasswordAsync(CompleteForgotPasswordInputModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseViewModel> ChangePasswordAsync(ChangePasswordInputModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserInputModel GetUserById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ResponseViewModel GetUserDetails();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        ResponseViewModel RequestForOTP(string emailAddress, string platform);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResponseViewModel ConfirmOTP(ConfirmOTPInputModel model);

        /// <summary>
        /// Get Current Logged On User Object
        /// </summary>
        /// <returns></returns>
        Task<AppUser> GetCurrentLoggedOnUserAsync();

        /// <summary>
        /// Update Current User
        /// </summary>
        /// <returns></returns>
        Task<AppUser> UpdateCurrentUserAsync(AppUser appUser);

        /// <summary>
        /// Create Vendor & Assign Role to it
        /// </summary>
        /// <param name="vendor"></param>
        /// <returns></returns>
        Task<ResponseViewModel> CreateVendor(VendorCreateInputModel vendor);
    }
}