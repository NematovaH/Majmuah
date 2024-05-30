using Majmuah.DataAccess.Contexts;
using Majmuah.DataAccess.Repositories;
using Majmuah.Domain.Entities.Categories;
using Majmuah.Domain.Entities.Collections;
using Majmuah.Domain.Entities.Comments;
using Majmuah.Domain.Entities.Commons;
using Majmuah.Domain.Entities.Fields;
using Majmuah.Domain.Entities.Items;
using Majmuah.Domain.Entities.Likes;
using Majmuah.Domain.Entities.Tags;
using Majmuah.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Storage;

namespace Majmuah.DataAccess.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    public IRepository<User> Users { get; }
    public IRepository<Asset> Assets { get; }
    public IRepository<UserRole> UserRoles { get; }
    public IRepository<Permission> Permissions { get; }
    public IRepository<RolePermission> RolePermissions { get; }
    public IRepository<Category> Categories { get; set; }
    public IRepository<Collection> Collections { get; set; }
    public IRepository<Comment> Comments { get; set; }
    public IRepository<Field> Fields { get; set; }
    public IRepository<FieldValue> FieldValues { get; set; }
    public IRepository<Item> Items { get; set; }
    public IRepository<ItemTag> ItemTags { get; set; }
    public IRepository<Like> Likes { get; set; }
    public IRepository<Tag> Tags { get; set; }

    private IDbContextTransaction transaction;

    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
        Users = new Repository<User>(this.context);
        Assets = new Repository<Asset>(this.context);
        UserRoles = new Repository<UserRole>(this.context);
        Permissions = new Repository<Permission>(this.context);
        RolePermissions = new Repository<RolePermission>(this.context);
        Categories = new Repository<Category>(this.context);
        Collections = new Repository<Collection>(this.context);
        Comments = new Repository<Comment>(this.context);
        Fields = new Repository<Field>(this.context);
        FieldValues = new Repository<FieldValue>(this.context);
        Tags = new Repository<Tag>(this.context);
        Likes = new Repository<Like>(this.context);
        Items = new Repository<Item>(this.context);
        ItemTags = new Repository<ItemTag>(this.context);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async ValueTask<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public async ValueTask BeginTransactionAsync()
    {
        transaction = await context.Database.BeginTransactionAsync();
    }

    public async ValueTask CommitTransactionAsync()
    {
        await transaction.CommitAsync();
    }
}
