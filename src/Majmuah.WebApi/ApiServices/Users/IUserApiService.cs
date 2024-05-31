using Majmuah.Service.Configurations;
using Majmuah.WebApi.Models.Users;

namespace Majmuah.WebApi.ApiServices.Users;

public interface IUserApiService
{
    ValueTask<UserViewModel> PostUserAsync(UserCreateModel createModel);
    ValueTask<UserViewModel> PostAdminAsync(UserCreateModel createModel);
    ValueTask<UserViewModel> PutAsync(long id, UserUpdateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<UserViewModel> GetAsync(long id);
    ValueTask<IEnumerable<UserViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<UserViewModel> ChangePasswordAsync(UserChangePasswordModel changePasswordModel);
}