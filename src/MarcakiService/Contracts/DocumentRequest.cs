using MarcakiService.Domain.Entities.ValueObjects;

namespace MarcakiService.Application.Contracts;

public class DocumentRequest
{
    public string Type { get; set; }
    public string Number { get; set; }

    public Document ToDomain()
    {
        return new Document(Type, Number);
    }
}