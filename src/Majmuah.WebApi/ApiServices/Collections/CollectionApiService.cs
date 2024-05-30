using AutoMapper;
using Majmuah.Domain.Entities.Collections;
using Majmuah.Service.Configurations;
using Majmuah.Service.Services.Collections;
using Majmuah.WebApi.Extensions;
using Majmuah.WebApi.Models.Collections;
using Majmuah.WebApi.Validators.Collections;

namespace Majmuah.WebApi.ApiServices.Collections;

public class CollectionApiService(
    IMapper mapper,
    ICollectionService collectionService,
    CollectionCreateModelValidator createModelValidator,
    CollectionUpdateModelValidator updateModelValidator) : ICollectionApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await collectionService.DeleteAsync(id);
    }

    public async ValueTask<CollectionViewModel> GetAsync(long id)
    {
        var collection = await collectionService.GetByIdAsync(id);
        return mapper.Map<CollectionViewModel>(collection);
    }

    public async ValueTask<IEnumerable<CollectionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var collections = await collectionService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<CollectionViewModel>>(collections);
    }

    public async ValueTask<CollectionViewModel> PostAsync(CollectionCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedCollection = mapper.Map<Collection>(createModel);
        var createdCollection = await collectionService.CreateAsync(mappedCollection);
        return mapper.Map<CollectionViewModel>(createdCollection);
    }

    public async ValueTask<CollectionViewModel> PutAsync(long id, CollectionUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedCollection = mapper.Map<Collection>(updateModel);
        var createdCollection = await collectionService.UpdateAsync(id, mappedCollection);
        return mapper.Map<CollectionViewModel>(createdCollection);
    }
}