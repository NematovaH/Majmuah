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

namespace Majmuah.DataAccess.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Asset> Assets { get; }
    IRepository<UserRole> UserRoles { get; }
    IRepository<Permission> Permissions { get; }
    IRepository<RolePermission> RolePermissions { get; }
    IRepository<Category> Categories { get; set; }
    IRepository<Collection> Collections { get; set; }
    IRepository<Comment> Comments { get; set; }
    IRepository<Field> Fields { get; set; }
    IRepository<FieldValue> FieldValues { get; set; }
    IRepository<Item> Items { get; set; }
    IRepository<ItemTag> ItemTags { get; set; }
    IRepository<Like> Likes { get; set; }
    IRepository<Tag> Tags { get; set; }
    ValueTask<bool> SaveAsync();
    ValueTask BeginTransactionAsync();
    ValueTask CommitTransactionAsync();
}