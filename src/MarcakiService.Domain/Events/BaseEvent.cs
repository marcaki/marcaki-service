namespace MarcakiService.Domain.Events;

public abstract class BaseEvent : IEvent
{
    public string Id { get; set; }
    public DateTime EventCommittedTimestamp { get; set; }

    public BaseEvent()
    {
        Id = new Guid().ToString();
        EventCommittedTimestamp = DateTime.UtcNow;;
    }

    public abstract int AggregateVersion { get; set; }
}