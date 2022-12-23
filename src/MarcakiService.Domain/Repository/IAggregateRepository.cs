using MarcakiService.Domain.Entities.Aggregates;
using MarcakiService.Domain.Events;

namespace MarcakiService.Domain.Repository;

public interface IAggregateRepository : IRepository<AggregateRoot>
{
    List<EventPayload> GetEvents();
}