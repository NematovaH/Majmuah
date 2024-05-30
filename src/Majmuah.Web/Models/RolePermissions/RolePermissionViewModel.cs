using Majmuah.WebApi.Models.Permissions;
using Majmuah.WebApi.Models.UserRoles;

namespace Majmuah.WebApi.Models.RolePermissions;

public class RolePermissionViewModel
{
    public long Id { get; set; }
    public UserRoleViewModel Role { get; set; }
    public PermissionViewModel Permission { get; set; }
}
