using Majmuah.WebApi.Models.Accounts;
using Majmuah.WebApi.Models.Users;

namespace Majmuah.WebApi.ApiServices.Accounts;

public interface IAccountApiService
{
    ValueTask<UserLoginViewModel> LoginAsync(LoginModel loginModel);
    ValueTask<bool> ResetPasswordAsync(ResetPasswordModel resetPasswordModel);
    ValueTask<bool> SendCodeAsync(SendCodeModel sendCodeModel);
    ValueTask<bool> ConfirmCodeAsync(ConfirmCodeModel confirmCodeModel);
}