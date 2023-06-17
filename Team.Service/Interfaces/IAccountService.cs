using Domain.Response;
using System.Security.Claims;
using Domain.Response;
using Domain.ViewModel.Account;
using System.Threading.Tasks;


namespace Proj_3.DAL.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
       // Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model);
    }
}
