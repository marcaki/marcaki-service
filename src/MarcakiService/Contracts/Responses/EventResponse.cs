namespace MarcakiService.Application.Contracts.Responses;

public class EventResponse
{
    public virtual string Id { get; set; }
    public virtual object Payload { get; set; }
    public virtual string EventKey { get; set; }
    public virtual string EventType { get; set; }
    
    public EventResponse(object payload, string eventKey, string eventType)
    {
        Id = eventKey;
        Payload = payload;
        EventKey = eventKey;
        EventType = eventType;
    }
}