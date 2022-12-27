using MarcakiService.Domain.Events;

namespace MarcakiService.Domain.Entities.Aggregates;

public class AggregateRoot : Entity
{
    public List<BaseEvent> Events { get; set; } = new List<BaseEvent>();
    public int AggregateVersion { get; set; }
    public string AggregateId { get; set; }

    public AggregateRoot()
    {
        AggregateId = Guid.NewGuid().ToString();
        Id = AggregateId;
    }

    public void AddEvent(BaseEvent evt)
    {
        Events.Add(evt);
        AggregateVersion = evt.AggregateVersion + 1;
    }
}