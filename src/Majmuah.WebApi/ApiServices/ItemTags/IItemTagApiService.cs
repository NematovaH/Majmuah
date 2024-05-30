using Majmuah.Service.Configurations;
using Majmuah.WebApi.Models.ItemTags;

namespace Majmuah.WebApi.ApiServices.ItemTags;

public interface IItemTagApiService
{
    ValueTask<ItemTagViewModel> PostAsync(ItemTagCreateModel createModel);
    ValueTask<ItemTagViewModel> PutAsync(long id, ItemTagUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<ItemTagViewModel> GetAsync(long id);
    ValueTask<IEnumerable<ItemTagViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}