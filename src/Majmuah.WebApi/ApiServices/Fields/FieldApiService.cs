using AutoMapper;
using Majmuah.Domain.Entities.Fields;
using Majmuah.Service.Configurations;
using Majmuah.Service.Services.Fields;
using Majmuah.WebApi.Extensions;
using Majmuah.WebApi.Models.Fields;
using Majmuah.WebApi.Validators.Fields;

namespace Majmuah.WebApi.ApiServices.Fields;

public class FieldApiService(
    IMapper mapper,
    IFieldService fieldService,
    FieldCreateModelValidator createModelValidator,
    FieldUpdateModelValidator updateModelValidator) : IFieldApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await fieldService.DeleteAsync(id);
    }

    public async ValueTask<FieldViewModel> GetAsync(long id)
    {
        var field = await fieldService.GetByIdAsync(id);
        return mapper.Map<FieldViewModel>(field);
    }

    public async ValueTask<IEnumerable<FieldViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var fields = await fieldService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<FieldViewModel>>(fields);
    }

    public async ValueTask<FieldViewModel> PostAsync(FieldCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedField = mapper.Map<Field>(createModel);
        var createdField = await fieldService.CreateAsync(mappedField);
        return mapper.Map<FieldViewModel>(createdField);
    }

    public async ValueTask<FieldViewModel> PutAsync(long id, FieldUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedField = mapper.Map<Field>(updateModel);
        var createdField = await fieldService.UpdateAsync(id, mappedField);
        return mapper.Map<FieldViewModel>(createdField);
    }
}