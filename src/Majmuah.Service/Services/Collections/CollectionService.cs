using Majmuah.DataAccess.UnitOfWorks;
using Majmuah.Domain.Entities.Collections;
using Majmuah.Service.Configurations;
using Majmuah.Service.Exceptions;
using Majmuah.Service.Extensions;
using Majmuah.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Majmuah.Service.Services.Collections;

public class CollectionService(IUnitOfWork unitOfWork) : ICollectionService
{
    public async ValueTask<Collection> CreateAsync(Collection collection)
    {
        var existUser = await unitOfWork.Users.SelectAsync(u => u.Id == collection.UserId)
            ?? throw new NotFoundException($"User is not found with this ID={collection.UserId}");

        var existCategory = await unitOfWork.Categories.SelectAsync(c => c.Id == collection.CategoryId)
            ?? throw new NotFoundException($"Category is not found with this ID={collection.CategoryId}");

        var existCollection = await unitOfWork.Collections.SelectAsync(c => c.Name.ToLower() == collection.Name.ToLower());
        if (existCollection is not null)
            throw new AlreadyExistException("This collection already exists");

        collection.CreatedByUserId = HttpContextHelper.UserId;
        var createdCollection = await unitOfWork.Collections.InsertAsync(collection);
        await unitOfWork.SaveAsync();

        return createdCollection;
    }

    public async ValueTask<Collection> UpdateAsync(long id, Collection collection)
    {
        var existCollection = await unitOfWork.Collections.SelectAsync(c => c.Id == id)
            ?? throw new NotFoundException($"Collection is not found with this ID={id}");

        var alreadyExistCollection = await unitOfWork.Collections.SelectAsync(c => c.Name.ToLower() == collection.Name.ToLower());
        if (alreadyExistCollection is not null)
            throw new AlreadyExistException("This collection already exists");

        existCollection.Name = collection.Name;
        existCollection.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Collections.UpdateAsync(collection);
        await unitOfWork.SaveAsync();

        return existCollection;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existCollection = await unitOfWork.Collections.SelectAsync(c => c.Id == id)
            ?? throw new NotFoundException($"Collection is not found with this ID={id}");

        existCollection.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Collections.DeleteAsync(existCollection);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<Collection> GetByIdAsync(long id)
    {
        var existCollection = await unitOfWork.Collections.SelectAsync(c => c.Id == id)
            ?? throw new NotFoundException($"Collection is not found with this ID={id}");

        return existCollection;
    }

    public async ValueTask<IEnumerable<Collection>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var collections = unitOfWork.Collections.SelectAsQueryable().OrderBy(filter);
        if(!string.IsNullOrEmpty(search))
            collections = collections.Where(c => c.Name.Contains(search, StringComparison.OrdinalIgnoreCase));

        return await collections.ToPaginateAsQueryable(@params).ToListAsync();
    }
}