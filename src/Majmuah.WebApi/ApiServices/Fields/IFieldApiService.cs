using Majmuah.Service.Configurations;
using Majmuah.WebApi.Models.Fields;

namespace Majmuah.WebApi.ApiServices.Fields;

public interface IFieldApiService
{
    ValueTask<FieldViewModel> PostAsync(FieldCreateModel createModel);
    ValueTask<FieldViewModel> PutAsync(long id, FieldUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<FieldViewModel> GetAsync(long id);
    ValueTask<IEnumerable<FieldViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}