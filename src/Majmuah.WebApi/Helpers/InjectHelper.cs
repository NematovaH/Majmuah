using Majmuah.Service.Services.Permissions;
using Majmuah.Service.Services.RolePermissions;
using Majmuah.Service.Services.UserRoles;
using Majmuah.Service.Services.Users;

namespace Majmuah.WebApi.Helpers;

public static class InjectHelper
{
    public static IUserService UserService;
    public static IUserRoleService UserRoleService;
    public static IPermissionService PermissionService;
    public static IRolePermissionService RolePermissionService;
}