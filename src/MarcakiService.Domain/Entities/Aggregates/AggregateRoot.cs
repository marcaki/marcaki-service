using MarcakiService.Domain.Events;

namespace MarcakiService.Domain.Entities.Aggregates;

public class AggregateRoot : Entity
{
    public List<Event> Events { get; set; }
    public List<Event> UncommitedEvents { get; set; }
    public int AggregateVersion { get; set; }
}