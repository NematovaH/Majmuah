using Majmuah.DataAccess.UnitOfWorks;
using Majmuah.Service.Helpers;
using Majmuah.Service.Services.Assets;
using Majmuah.Service.Services.Categories;
using Majmuah.Service.Services.Collections;
using Majmuah.Service.Services.Comments;
using Majmuah.Service.Services.Fields;
using Majmuah.Service.Services.FieldValues;
using Majmuah.Service.Services.Items;
using Majmuah.Service.Services.ItemTags;
using Majmuah.Service.Services.Likes;
using Majmuah.Service.Services.Tags;
using Majmuah.Service.Services.Users;
using Majmuah.WebApi.ApiServices.Accounts;
using Majmuah.WebApi.ApiServices.Categories;
using Majmuah.WebApi.ApiServices.Collections;
using Majmuah.WebApi.ApiServices.Fields;
using Majmuah.WebApi.ApiServices.FieldValues;
using Majmuah.WebApi.ApiServices.Items;
using Majmuah.WebApi.ApiServices.ItemTags;
using Majmuah.WebApi.ApiServices.LessonComments;
using Majmuah.WebApi.ApiServices.Likes;
using Majmuah.WebApi.ApiServices.Tags;
using Majmuah.WebApi.ApiServices.Users;
using Majmuah.WebApi.Middlewares;
using Majmuah.WebApi.Validators.Accounts;
using Majmuah.WebApi.Validators.Assets;
using Majmuah.WebApi.Validators.Categories;
using Majmuah.WebApi.Validators.Collections;
using Majmuah.WebApi.Validators.Comments;
using Majmuah.WebApi.Validators.Fields;
using Majmuah.WebApi.Validators.FieldValues;
using Majmuah.WebApi.Validators.Items;
using Majmuah.WebApi.Validators.ItemTags;
using Majmuah.WebApi.Validators.Likes;
using Majmuah.WebApi.Validators.Tags;
using Majmuah.WebApi.Validators.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Majmuah.WebApi.Extensions;

public static class ServicesCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAssetService, AssetService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICollectionService, CollectionService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IFieldService, FieldService>();
        services.AddScoped<IFieldValueService, FieldValueService>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IItemTagService, ItemTagService>();
        services.AddScoped<ILikeService, LikeService>();
        services.AddScoped<ITagService, TagService>();
    }

    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<IUserApiService, UserApiService>();
        services.AddScoped<IAccountApiService, AccountApiService>();
        services.AddScoped<ITagApiService, TagApiService>();
        services.AddScoped<ILikeApiService, LikeApiService>();
        services.AddScoped<IItemTagApiService, ItemTagApiService>();
        services.AddScoped<IItemApiService, ItemApiService>();
        services.AddScoped<IFieldValueApiService, FieldValueApiService>();
        services.AddScoped<IFieldApiService, FieldApiService>();
        services.AddScoped<ICommentApiService, CommentApiService>();
        services.AddScoped<ICollectionApiService, CollectionApiService>();
        services.AddScoped<ICategoryApiService, CategoryApiService>();
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddTransient<UserCreateModelValidator>();
        services.AddTransient<UserUpdateModelValidator>();
        services.AddTransient<UserChangePasswordModelValidator>();

        services.AddTransient<LoginModelValidator>();
        services.AddTransient<ResetPasswordModelValidator>();
        services.AddTransient<SendCodeModelValidator>();
        services.AddTransient<ConfirmCodeModelValidator>();

        services.AddTransient<AssetCreateModelValidator>();

        services.AddTransient<CategoryCreateModelValidator>();
        services.AddTransient<CategoryUpdateModelValidator>();

        services.AddTransient<CollectionCreateModelValidator>();
        services.AddTransient<CollectionUpdateModelValidator>();

        services.AddTransient<CommentCreateModelValidator>();
        services.AddTransient<CommentUpdateModelValidator>();

        services.AddTransient<FieldCreateModelValidator>();
        services.AddTransient<FieldUpdateModelValidator>();

        services.AddTransient<FieldValueCreateModelValidator>();
        services.AddTransient<FieldValueUpdateModelValidator>();

        services.AddTransient<ItemCreateModelValidator>();
        services.AddTransient<ItemUpdateModelValidator>();

        services.AddTransient<ItemTagCreateModelValidator>();
        services.AddTransient<ItemTagUpdateModelValidator>();

        services.AddTransient<LikeCreateModelValidator>();

        services.AddTransient<TagCreateModelValidator>();
        services.AddTransient<TagUpdateModelValidator>();
    }

    public static void AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<NotFoundExceptionHandler>();
        services.AddExceptionHandler<AlreadyExistExceptionHandler>();
        services.AddExceptionHandler<ArgumentIsNotValidExceptionHandler>();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddExceptionHandler<InternalServerExceptionHandler>();
    }

    public static void AddInjectEnvironmentItems(this WebApplication app)
    {
        HttpContextHelper.ContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
        EnvironmentHelper.WebRootPath = Path.GetFullPath("wwwroot");
        EnvironmentHelper.JWTKey = app.Configuration.GetSection("JWT:Key").Value;
        EnvironmentHelper.TokenLifeTimeInHours = app.Configuration.GetSection("JWT:LifeTime").Value;
        EnvironmentHelper.EmailAddress = app.Configuration.GetSection("Email:EmailAddress").Value;
        EnvironmentHelper.EmailPassword = app.Configuration.GetSection("Email:Password").Value;
        EnvironmentHelper.SmtpPort = app.Configuration.GetSection("Email:Port").Value;
        EnvironmentHelper.SmtpHost = app.Configuration.GetSection("Email:Host").Value;
        EnvironmentHelper.PageSize = Convert.ToInt32(app.Configuration.GetSection("PaginationParams:PageSize").Value);
        EnvironmentHelper.PageIndex = Convert.ToInt32(app.Configuration.GetSection("PaginationParams:PageIndex").Value);
    }

    public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            var key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(setup =>
        {
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
        });
    }
}