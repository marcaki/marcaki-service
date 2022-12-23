using MarcakiService.Domain.Entities.Projections;
using MarcakiService.Domain.Repository;

namespace MarcakiService.Repository;

public class ProviderRepository : IProviderRepository
{
    private ReadmodelContext _readModelContext;

    public ProviderRepository(ReadmodelContext readModelContext)
    {
        _readModelContext = readModelContext;
    }
    
    public async Task<string> Add(ProviderProjection entity)
    {
        await _readModelContext.Providers.AddAsync(entity);
        return entity.Id;
    }

    public List<ProviderProjection> GetAll()
    {
        return _readModelContext.Providers.ToList();
    }
}