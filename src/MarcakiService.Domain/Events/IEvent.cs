namespace MarcakiService.Domain.Events;

public interface IEvent
{
    int AggregateVersion { get; set; }
    string AggregateId { get; set; }
}