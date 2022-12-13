using MarcakiService.Domain.Events;
using MarcakiService.Domain.Exceptions;

namespace MarcakiService.Domain.Entities.Aggregates;

public class AggregateRoot : Entity
{
    public List<IEvent> Events { get; set; }
    private List<IEvent> UncommitedEvents { get; set; }
    public int AggregateVersion { get; set; }

    public void AddEvent(IEvent evt)
    {
        var eventCommitted = UncommitedEvents.Exists(x => x.AggregateVersion == evt.AggregateVersion);
        if (eventCommitted == false)
        {
            UncommitedEvents.Add(evt);
        }

        throw new AggregateMismatchException("There are event with same version on aggregate");
    }
}