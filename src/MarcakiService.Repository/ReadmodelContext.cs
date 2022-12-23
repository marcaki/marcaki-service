using MarcakiService.Domain.Entities.Aggregates;
using MarcakiService.Domain.Entities.Projections;
using MarcakiService.Domain.Entities.ValueObjects;
using MarcakiService.Repository.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MarcakiService.Repository;

public class ReadmodelContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase(databaseName: "MarcakiDb");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Availability>().HasKey(x => x.Id);
        modelBuilder.Entity<Phone>().HasNoKey();
        modelBuilder.ApplyConfiguration(new ProviderMapping());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ProviderProjection> Providers { get; set; }
}