using Majmuah.Service.Configurations;
using Majmuah.WebApi.Models.Items;

namespace Majmuah.WebApi.ApiServices.Items;

public interface IItemApiService
{
    ValueTask<ItemViewModel> PostAsync(ItemCreateModel createModel);
    ValueTask<ItemViewModel> PutAsync(long id, ItemUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<ItemViewModel> GetAsync(long id);
    ValueTask<IEnumerable<ItemViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}