using Majmuah.Domain.Entities.Users;
using Majmuah.Service.Configurations;

namespace Majmuah.Service.Services.RolePermissions;

public interface IRolePermissionService
{
    ValueTask<RolePermission> CreateAsync(RolePermission rolePermission);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<RolePermission> GetByIdAsync(long id);
    ValueTask<IEnumerable<RolePermission>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<IEnumerable<RolePermission>> GetAllByRoleIdAsync(long roleId);
    bool CheckRolePermission(string role, string action, string controller);
}