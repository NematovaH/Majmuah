using Microsoft.EntityFrameworkCore;

namespace Majmuah.DataAccess.EntityConfigurations.Commons;

public interface IEntityConfiguration
{
    void Configure(ModelBuilder modelBuilder);
    void SeedData(ModelBuilder modelBuilder);
}