using MarcakiService.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace MarcakiService.Repository;

public class EventSourceContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase(databaseName: "MarcakiServiceDb");
    }
    
    public DbSet<IEvent> Events { get; set; }
}