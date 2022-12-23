namespace MarcakiService.Domain.Events;

public class EventPayload
{
    public virtual string Id { get; set; }
    public virtual string Payload { get; set; }
    public virtual string EventKey { get; set; }
    public virtual string EventType { get; set; }
    
    public EventPayload(string payload, string eventKey, string eventType)
    {
        Id = eventKey;
        Payload = payload;
        EventKey = eventKey;
        EventType = eventType;
    }

    public EventPayload()
    {
        
    }
}