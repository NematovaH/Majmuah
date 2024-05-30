﻿using Majmuah.DataAccess.EntityConfigurations.Commons;
using Majmuah.Domain.Entities.Categories;
using Majmuah.Domain.Entities.Collections;
using Majmuah.Domain.Entities.Comments;
using Majmuah.Domain.Entities.Commons;
using Majmuah.Domain.Entities.Fields;
using Majmuah.Domain.Entities.Items;
using Majmuah.Domain.Entities.Likes;
using Majmuah.Domain.Entities.Tags;
using Majmuah.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Majmuah.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Collection> Collections { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Field> Fields { get; set; }
    public DbSet<FieldValue> FieldValues { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ItemTag> ItemTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Many-to-many relationship between Item and Tag
        modelBuilder.Entity<ItemTag>()
            .HasKey(it => new { it.ItemId, it.TagId });

        modelBuilder.Entity<ItemTag>()
            .HasOne(it => it.Item)
            .WithMany(i => i.ItemTags)
            .HasForeignKey(it => it.ItemId);

        modelBuilder.Entity<ItemTag>()
            .HasOne(it => it.Tag)
            .WithMany(t => t.ItemTags)
            .HasForeignKey(it => it.TagId);

        // One-to-many relationship between Collection and Field
        modelBuilder.Entity<Field>()
            .HasOne(f => f.Collection)
            .WithMany(c => c.Fields)
            .HasForeignKey(f => f.CollectionId);

        // One-to-many relationship between Item and FieldValue
        modelBuilder.Entity<FieldValue>()
            .HasOne(fv => fv.Item)
            .WithMany(i => i.FieldValues)
            .HasForeignKey(fv => fv.ItemId);

        modelBuilder.Entity<FieldValue>()
            .HasOne(fv => fv.Field)
            .WithMany()
            .HasForeignKey(fv => fv.FieldId);

        // One-to-many relationship between Collection and Item
        modelBuilder.Entity<Item>()
            .HasOne(i => i.Collection)
            .WithMany(c => c.Items)
            .HasForeignKey(i => i.CollectionId);

        // One-to-many relationship between User and Collection
        modelBuilder.Entity<Collection>()
            .HasOne(c => c.User)
            .WithMany(u => u.Collections)
            .HasForeignKey(c => c.UserId);

        // One-to-many relationship between Category and Collection
        modelBuilder.Entity<Collection>()
            .HasOne(c => c.Category)
            .WithMany(cat => cat.Collections)
            .HasForeignKey(c => c.CategoryId);

        // One-to-many relationship between UserRole and User
        modelBuilder.Entity<User>()
            .HasOne(u => u.UserRole)
            .WithMany(ur => ur.Users)
            .HasForeignKey(u => u.RoleId);

        // One-to-many relationship between UserRole and RolePermission
        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId);

        // One-to-many relationship between Permission and RolePermission
        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany()
            .HasForeignKey(rp => rp.PermissionId);

        // One-to-many relationship between Item and Like
        modelBuilder.Entity<Like>()
            .HasOne(l => l.Item)
            .WithMany(i => i.Likes)
            .HasForeignKey(l => l.ItemId);

        // One-to-many relationship between User and Like
        modelBuilder.Entity<Like>()
            .HasOne(l => l.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.UserId);

        // One-to-many relationship between Item and Comment
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Item)
            .WithMany(i => i.Comments)
            .HasForeignKey(c => c.ItemId);

        // One-to-many relationship between User and Comment
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId);

        // Self-referencing relationship for Comment replies
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Parent)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ParentId);

        ApplyConfigurations(modelBuilder);
    }
    private void ApplyConfigurations(ModelBuilder modelBuilder)
    {
        var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !string.IsNullOrEmpty(type.Namespace))
            .Where(type => type.GetInterfaces().Any(inter => inter == typeof(IEntityConfiguration)));
        foreach (var type in typesToRegister)
        {
            var configuration = (IEntityConfiguration)Activator.CreateInstance(type);
            configuration.Configure(modelBuilder);
            configuration.SeedData(modelBuilder);
        }
    }
}