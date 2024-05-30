using AutoMapper;
using Majmuah.Domain.Entities.Categories;
using Majmuah.Domain.Entities.Collections;
using Majmuah.Domain.Entities.Comments;
using Majmuah.Domain.Entities.Commons;
using Majmuah.Domain.Entities.Fields;
using Majmuah.Domain.Entities.Items;
using Majmuah.Domain.Entities.Likes;
using Majmuah.Domain.Entities.Tags;
using Majmuah.Domain.Entities.Users;
using Majmuah.WebApi.Models.Assets;
using Majmuah.WebApi.Models.Categories;
using Majmuah.WebApi.Models.Collections;
using Majmuah.WebApi.Models.Comments;
using Majmuah.WebApi.Models.Fields;
using Majmuah.WebApi.Models.FieldValues;
using Majmuah.WebApi.Models.Items;
using Majmuah.WebApi.Models.ItemTags;
using Majmuah.WebApi.Models.Likes;
using Majmuah.WebApi.Models.Permissions;
using Majmuah.WebApi.Models.RolePermissions;
using Majmuah.WebApi.Models.Tags;
using Majmuah.WebApi.Models.UserRoles;
using Majmuah.WebApi.Models.Users;

namespace Majmuah.WebApi.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AssetViewModel, Asset>().ReverseMap();

        CreateMap<PermissionViewModel, Permission>().ReverseMap();
        CreateMap<Permission, PermissionCreateModel>().ReverseMap();
        CreateMap<Permission, PermissionUpdateModel>().ReverseMap();

        CreateMap<RolePermissionViewModel, RolePermission>().ReverseMap();
        CreateMap<RolePermission, RolePermissionCreateModel>().ReverseMap();

        CreateMap<UserRoleViewModel, UserRole>().ReverseMap();
        CreateMap<UserRole, UserRoleCreateModel>().ReverseMap();
        CreateMap<UserRole, UserRoleUpdateModel>().ReverseMap();

        CreateMap<UserViewModel, User>().ReverseMap();
        CreateMap<UserLoginViewModel, User>().ReverseMap();
        CreateMap<User, UserCreateModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();

        CreateMap<LikeViewModel, Like>().ReverseMap();
        CreateMap<Like, LikeCreateModel>().ReverseMap();

        CreateMap<ItemTagViewModel, ItemTag>().ReverseMap();
        CreateMap<ItemTag, ItemTagCreateModel>().ReverseMap();
        CreateMap<ItemTag, ItemTagUpdateModel>().ReverseMap();

        CreateMap<TagViewModel, Tag>().ReverseMap();
        CreateMap<Tag, TagCreateModel>().ReverseMap();
        CreateMap<Tag, TagUpdateModel>().ReverseMap();

        CreateMap<ItemViewModel, Item>().ReverseMap();
        CreateMap<Item, ItemCreateModel>().ReverseMap();
        CreateMap<Item, ItemUpdateModel>().ReverseMap();

        CreateMap<FieldViewModel, Field>().ReverseMap();
        CreateMap<Field, FieldCreateModel>().ReverseMap();
        CreateMap<Field, FieldUpdateModel>().ReverseMap();

        CreateMap<FieldValueViewModel, FieldValue>().ReverseMap();
        CreateMap<FieldValue, FieldValueCreateModel>().ReverseMap();
        CreateMap<FieldValue, FieldValueUpdateModel>().ReverseMap();

        CreateMap<CommentViewModel, Comment>().ReverseMap();
        CreateMap<Comment, CommentCreateModel>().ReverseMap();
        CreateMap<Comment, CommentUpdateModel>().ReverseMap();

        CreateMap<CollectionViewModel, Collection>().ReverseMap();
        CreateMap<Collection, CollectionCreateModel>().ReverseMap();
        CreateMap<Collection, CollectionUpdateModel>().ReverseMap();

        CreateMap<CategoryViewModel, Category>().ReverseMap();
        CreateMap<Category, CategoryCreateModel>().ReverseMap();
        CreateMap<Category, CategoryUpdateModel>().ReverseMap();
    }
}
