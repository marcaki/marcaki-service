using MarcakiService.Domain.Entities.Aggregates;
using MediatR;
using Newtonsoft.Json;

namespace MarcakiService.Domain.Events;

public class BaseEvent : IEvent, INotification
{
    public string Id { get; set; }
    public DateTime EventCommittedTimestamp { get; set; }
    public int AggregateVersion { get; set; }
    public string AggregateId { get; set; }
    public AggregateRoot AggregateRoot { get; set; }
    public string AggregateType { get; set; }
    
    public BaseEvent(string aggregateId)
    {
        Id = aggregateId;
        AggregateId = aggregateId;
        EventCommittedTimestamp = DateTime.UtcNow;;
    }

    protected BaseEvent()
    {
        
    }

    public virtual string SerializePayload()
    {
        return JsonConvert.SerializeObject(this);
    }
}