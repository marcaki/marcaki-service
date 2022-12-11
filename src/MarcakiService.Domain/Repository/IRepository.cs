using MarcakiService.Domain.Entities.Aggregates;

namespace MarcakiService.Domain.Repository;

public interface IRepository<T> where T : Entity
{
    Task<string> Add(T entity);
    List<T> GetAll();
}