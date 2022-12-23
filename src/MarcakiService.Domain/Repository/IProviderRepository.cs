using MarcakiService.Domain.Entities.Projections;

namespace MarcakiService.Domain.Repository;

public interface IProviderRepository : IProjectionRepository<ProviderProjection>
{
}