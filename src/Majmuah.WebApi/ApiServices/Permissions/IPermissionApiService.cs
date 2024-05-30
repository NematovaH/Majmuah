using Majmuah.Service.Configurations;
using Majmuah.WebApi.Models.Permissions;

namespace Majmuah.WebApi.ApiServices.Permissions;

public interface IPermissionApiService
{
    ValueTask<PermissionViewModel> PostAsync(PermissionCreateModel createModel);
    ValueTask<PermissionViewModel> PutAsync(long id, PermissionUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<PermissionViewModel> GetAsync(long id);
    ValueTask<IEnumerable<PermissionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}