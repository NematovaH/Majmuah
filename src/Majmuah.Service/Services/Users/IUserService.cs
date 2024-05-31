using Majmuah.Domain.Entities.Users;
using Majmuah.Service.Configurations;

namespace Majmuah.Service.Services.Users;

public interface IUserService
{
    ValueTask<User> CreateUserAsync(User user);
    ValueTask<User> CreateAdminAsync(User user);
    ValueTask<User> UpdateAsync(long id, User user);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<User> GetByIdAsync(long id);
    ValueTask<bool> RemoveAdminRoleAsync();
    ValueTask<IEnumerable<User>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<(User user, string token)> LoginAsync(string phone, string password);
    ValueTask<bool> ResetPasswordAsync(string phone, string newPassword);
    ValueTask<bool> SendCodeAsync(string phone);
    ValueTask<bool> ConfirmCodeAsync(string phone, string code);
    ValueTask<User> ChangePasswordAsync(string phone, string oldPassword, string newPassword);
}