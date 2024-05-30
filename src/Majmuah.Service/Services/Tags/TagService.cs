﻿using Majmuah.DataAccess.UnitOfWorks;
using Majmuah.Domain.Entities.Tags;
using Majmuah.Service.Configurations;
using Majmuah.Service.Exceptions;
using Majmuah.Service.Extensions;
using Majmuah.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Majmuah.Service.Services.Tags;

public class TagService(IUnitOfWork unitOfWork) : ITagService
{
    public async ValueTask<Tag> CreateAsync(Tag tag)
    {
        var existTag = await unitOfWork.Tags.SelectAsync(t => t.Name.ToLower() == tag.Name.ToLower());
        if (existTag is not null)
            throw new AlreadyExistException($"Tag with this name alreadyn exists");

        tag.CreatedByUserId = HttpContextHelper.UserId;
        var createdTag = await unitOfWork.Tags.InsertAsync(tag);
        await unitOfWork.SaveAsync();

        return createdTag;
    }

    public async ValueTask<Tag> UpdateAsync(long id, Tag tag)
    {
        var existTag = await unitOfWork.Tags.SelectAsync(t => t.Id == id)
            ?? throw new NotFoundException($"Tag is not found with this ID={id}");

        var alreadyExistTag = await unitOfWork.Tags.SelectAsync(t => t.Name.ToLower() == tag.Name.ToLower());
        if (alreadyExistTag is not null)
            throw new AlreadyExistException("This tag already exists");

        existTag.Name = tag.Name;

        existTag.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Tags.UpdateAsync(tag);
        await unitOfWork.SaveAsync();

        return existTag;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existTag = await unitOfWork.Tags.SelectAsync(t => t.Id == id)
            ?? throw new NotFoundException($"Tag is not found with this ID={id}");

        existTag.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Tags.DeleteAsync(existTag);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<Tag> GetByIdAsync(long id)
    {
        var existTag = await unitOfWork.Tags.SelectAsync(t => t.Id == id)
            ?? throw new NotFoundException($"Tag is not found with this ID={id}");

        return existTag;
    }

    public async ValueTask<IEnumerable<Tag>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var tags = unitOfWork.Tags.SelectAsQueryable().OrderBy(filter);
        if (!string.IsNullOrEmpty(search))
            tags = tags.Where(t => t.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
        
        return await tags.ToPaginateAsQueryable(@params).ToListAsync();
    }
}