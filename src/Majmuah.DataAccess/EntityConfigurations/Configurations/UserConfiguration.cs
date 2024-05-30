using Majmuah.DataAccess.EntityConfigurations.Commons;
using Majmuah.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Majmuah.DataAccess.EntityConfigurations.Configurations;

public class UserConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
    }
}