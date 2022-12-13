using MarcakiService.Domain.Entities.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace MarcakiService.Repository;

public class ReadmodelContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase(databaseName: "MarcakiServiceDb");
    }
    
    public DbSet<Provider> Providers { get; set; }
}