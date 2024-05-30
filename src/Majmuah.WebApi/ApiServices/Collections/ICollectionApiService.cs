using Majmuah.Service.Configurations;
using Majmuah.WebApi.Models.Collections;

namespace Majmuah.WebApi.ApiServices.Collections;

public interface ICollectionApiService
{
    ValueTask<CollectionViewModel> PostAsync(CollectionCreateModel createModel);
    ValueTask<CollectionViewModel> PutAsync(long id, CollectionUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CollectionViewModel> GetAsync(long id);
    ValueTask<IEnumerable<CollectionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}