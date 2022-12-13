using MarcakiService.Domain.Entities.Aggregates;

namespace MarcakiService.Domain.Repository;

public interface IAggregateRepository : IRepository<AggregateRoot>
{
    
}