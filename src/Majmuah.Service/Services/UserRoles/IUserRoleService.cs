using Majmuah.Domain.Entities.Users;
using Majmuah.Service.Configurations;

namespace Majmuah.Service.Services.UserRoles;

public interface IUserRoleService
{
    ValueTask<UserRole> CreateAsync(UserRole userRole);
    ValueTask<UserRole> UpdateAsync(long id, UserRole userRole);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<UserRole> GetByIdAsync(long id);
    ValueTask<IEnumerable<UserRole>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}