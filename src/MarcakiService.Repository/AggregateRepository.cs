using MarcakiService.Domain.Entities.Aggregates;
using MarcakiService.Domain.Repository;

namespace MarcakiService.Repository;

public class AggregateRepository : IAggregateRepository
{
    public Task<string> Add(AggregateRoot entity)
    {
        throw new NotImplementedException();
    }

    public List<AggregateRoot> GetAll()
    {
        throw new NotImplementedException();
    }
}