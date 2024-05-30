using Majmuah.DataAccess.EntityConfigurations.Commons;
using Majmuah.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Majmuah.DataAccess.EntityConfigurations.Configurations;

public class RolePermissionConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // RolePermission and Role
        modelBuilder.Entity<RolePermission>()
            .HasOne(rolePermission => rolePermission.Role)
            .WithMany()
            .HasForeignKey(rolePermission => rolePermission.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        // RolePermission and Permission
        modelBuilder.Entity<RolePermission>()
            .HasOne(rolePermission => rolePermission.Permission)
            .WithMany()
            .HasForeignKey(rolePermission => rolePermission.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
    }
}
