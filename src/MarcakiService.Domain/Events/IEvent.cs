namespace MarcakiService.Domain.Events;

public interface IEvent
{
    int AggregateVersion { get; set; }
}