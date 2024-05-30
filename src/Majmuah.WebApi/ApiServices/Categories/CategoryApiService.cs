﻿using AutoMapper;
using Majmuah.Domain.Entities.Categories;
using Majmuah.Service.Configurations;
using Majmuah.Service.Services.Categories;
using Majmuah.WebApi.Extensions;
using Majmuah.WebApi.Models.Categories;
using Majmuah.WebApi.Validators.Categories;

namespace Majmuah.WebApi.ApiServices.Categories;

public class CategoryApiService(
    IMapper mapper,
    ICategoryService categoryService,
    CategoryCreateModelValidator createModelValidator,
    CategoryUpdateModelValidator updateModelValidator) : ICategoryApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await categoryService.DeleteAsync(id);
    }

    public async ValueTask<CategoryViewModel> GetAsync(long id)
    {
        var category = await categoryService.GetByIdAsync(id);
        return mapper.Map<CategoryViewModel>(category);
    }

    public async ValueTask<IEnumerable<CategoryViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var category = await categoryService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<CategoryViewModel>>(category);
    }

    public async ValueTask<CategoryViewModel> PostAsync(CategoryCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedCategory = mapper.Map<Category>(createModel);
        var createdCategory = await categoryService.CreateAsync(mappedCategory);
        return mapper.Map<CategoryViewModel>(createdCategory);
    }

    public async ValueTask<CategoryViewModel> PutAsync(long id, CategoryUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedCategory = mapper.Map<Category>(updateModel);
        var createdCategory = await categoryService.UpdateAsync(id, mappedCategory);
        return mapper.Map<CategoryViewModel>(createdCategory);
    }
}
