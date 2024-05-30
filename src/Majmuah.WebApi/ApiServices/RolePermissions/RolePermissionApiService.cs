using AutoMapper;
using Majmuah.Domain.Entities.Users;
using Majmuah.Service.Configurations;
using Majmuah.Service.Services.RolePermissions;
using Majmuah.WebApi.Extensions;
using Majmuah.WebApi.Models.RolePermissions;
using Majmuah.WebApi.Validators.RolePermissions;

namespace Majmuah.WebApi.ApiServices.RolePermissions;

public class RolePermissionApiService(
    IMapper mapper,
    IRolePermissionService rolePermissionService,
    RolePermissionCreateModelValidator createValidator) : IRolePermissionApiService
{
    public async ValueTask<RolePermissionViewModel> PostAsync(RolePermissionCreateModel createModel)
    {
        await createValidator.EnsureValidatedAsync(createModel);
        var mappedRolePermission = mapper.Map<RolePermission>(createModel);
        var createdRolePermission = await rolePermissionService.CreateAsync(mappedRolePermission);
        return mapper.Map<RolePermissionViewModel>(createdRolePermission);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await rolePermissionService.DeleteAsync(id);
    }

    public async ValueTask<RolePermissionViewModel> GetAsync(long id)
    {
        var rolePermission = await rolePermissionService.GetByIdAsync(id);
        return mapper.Map<RolePermissionViewModel>(rolePermission);
    }

    public async ValueTask<IEnumerable<RolePermissionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var rolePermissions = await rolePermissionService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<RolePermissionViewModel>>(rolePermissions);
    }
}