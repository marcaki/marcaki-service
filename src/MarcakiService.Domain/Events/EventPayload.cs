namespace MarcakiService.Domain.Events;

public class EventPayload
{
    public virtual string Id { get; set; }
    public virtual string Payload { get; set; }
    public virtual string EventKey { get; set; }
    public string AggregateType { get; set; }
    
    public EventPayload(string payload, string eventKey, string aggregateType)
    {
        Id = eventKey;
        Payload = payload;
        EventKey = eventKey;
        AggregateType = aggregateType;
    }

    public EventPayload()
    {
        
    }
}