using MarcakiService.Domain.Entities.Aggregates;
using MarcakiService.Domain.Events;
using MarcakiService.Repository.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MarcakiService.Repository;

public class EventSourceContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase(databaseName: "MarcakiDb");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AggregateMapping());
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<AggregateRoot> Aggregates { get; set; }
    public DbSet<EventPayload> EventPayloads { get; set; }
}