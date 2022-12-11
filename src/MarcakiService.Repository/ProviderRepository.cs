using MarcakiService.Domain.Entities.Aggregates;
using MarcakiService.Domain.Repository;

namespace MarcakiService.Repository;

public class ProviderRepository : IProviderRepository
{
    private TContext _context;

    public ProviderRepository(TContext context)
    {
        _context = context;
    }
    
    public async Task<string> Add(Provider entity)
    {
        await _context.Providers.AddAsync(entity);
        return entity.Id;
    }

    public List<Provider> GetAll()
    {
        return _context.Providers.ToList();
    }
}