using MarcakiService.Domain.Entities.Projections;

namespace MarcakiService.Domain.Repository;

public interface IProjectionRepository<T> where T : Projection
{
    Task<string> Add(T entity);
    List<T> GetAll();
}