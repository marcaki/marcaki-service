using MarcakiService.Domain.Events;
using MarcakiService.Domain.Exceptions;

namespace MarcakiService.Domain.Entities.Aggregates;

public class AggregateRoot : Entity
{
    public List<BaseEvent> Events { get; set; } = new List<BaseEvent>();
    public List<BaseEvent> UncommittedEvents { get; set; } = new List<BaseEvent>();
    public int AggregateVersion { get; set; }
    public string AggregateId { get; set; }

    public AggregateRoot()
    {
        AggregateId = Guid.NewGuid().ToString();
        Id = AggregateId;
    }

    public void AddEvent(BaseEvent evt)
    {
        var eventCommitted = UncommittedEvents.Exists(x => x.AggregateVersion == evt.AggregateVersion);
        
        if (eventCommitted)
            throw new AggregateMismatchException("There are event with same version on aggregate");
        
        UncommittedEvents.Add(evt);
        Events.Add(evt);
        AggregateVersion = evt.AggregateVersion + 1;
    }
}