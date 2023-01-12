namespace MarcakiService.Domain.Entities.Aggregates;

public class Entity
{
    public string Id { get; set; }

    public Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
}