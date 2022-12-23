using System.Text.Json;
using MarcakiService.Domain.Entities.Aggregates;
using MarcakiService.Domain.Events;
using MarcakiService.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace MarcakiService.Repository;

public class AggregateRepository : IAggregateRepository
{
    private EventSourceContext _context;

    public AggregateRepository(EventSourceContext context)
    {
        _context = context;
        _context.Aggregates.Include(x => x.Events);
    }
    
    public async Task<string> Add(AggregateRoot entity)
    {
        var payloads = entity.Events.Select(x => new EventPayload(x.SerializePayload(), x.Id, x.AggregateType));
        _context.Aggregates.Add(entity);
        _context.EventPayloads.AddRange(payloads);
        
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public List<AggregateRoot> GetAll()
    {
        var aggregates = _context.Aggregates.ToList();
        return aggregates;
    }

    public List<EventPayload> GetEvents()
    {
        var events = _context.EventPayloads.ToList();
        return events;
    }
}