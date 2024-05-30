﻿using AutoMapper;
using Majmuah.Domain.Entities.Items;
using Majmuah.Service.Configurations;
using Majmuah.Service.Services.ItemTags;
using Majmuah.WebApi.Extensions;
using Majmuah.WebApi.Models.ItemTags;
using Majmuah.WebApi.Validators.ItemTags;

namespace Majmuah.WebApi.ApiServices.ItemTags;

public class ItemTagApiService(
    IMapper mapper,
    IItemTagService itemTagService,
    ItemTagCreateModelValidator createModelValidator,
    ItemTagUpdateModelValidator updateModelValidator) : IItemTagApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await itemTagService.DeleteAsync(id);
    }

    public async ValueTask<ItemTagViewModel> GetAsync(long id)
    {
        var itemTag = await itemTagService.GetByIdAsync(id);
        return mapper.Map<ItemTagViewModel>(itemTag);
    }

    public async ValueTask<IEnumerable<ItemTagViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var itemTags = await itemTagService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<ItemTagViewModel>>(itemTags);
    }

    public async ValueTask<ItemTagViewModel> PostAsync(ItemTagCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedItemTag = mapper.Map<ItemTag>(createModel);
        var createdItemTag = await itemTagService.CreateAsync(mappedItemTag);
        return mapper.Map<ItemTagViewModel>(createdItemTag);
    }

    public async ValueTask<ItemTagViewModel> PutAsync(long id, ItemTagUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedItemTag = mapper.Map<ItemTag>(updateModel);
        var createdItemTag = await itemTagService.UpdateAsync(id, mappedItemTag);
        return mapper.Map<ItemTagViewModel>(createdItemTag);
    }
}