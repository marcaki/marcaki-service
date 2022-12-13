using MarcakiService.Domain.Entities.Aggregates;
using MarcakiService.Domain.Repository;

namespace MarcakiService.Repository;

public class ProviderRepository : IProviderRepository
{
    private ReadmodelContext _readmodelContext;

    public ProviderRepository(ReadmodelContext readmodelContext)
    {
        _readmodelContext = readmodelContext;
    }
    
    public async Task<string> Add(Provider entity)
    {
        await _readmodelContext.Providers.AddAsync(entity);
        return entity.Id;
    }

    public List<Provider> GetAll()
    {
        return _readmodelContext.Providers.ToList();
    }
}