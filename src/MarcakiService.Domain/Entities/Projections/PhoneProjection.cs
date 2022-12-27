using MarcakiService.Domain.Entities.ValueObjects;

namespace MarcakiService.Domain.Entities.Projections;

public class PhoneProjection : Projection
{
    public string ProviderId { get; set; }
    public string Type { get; set; }
    public string Number { get; set; }
    public ProviderProjection Provider { get; set; }

    public PhoneProjection()
    {
        
    }

    public PhoneProjection(Phone phone)
    {
        Id = Guid.NewGuid().ToString();
        Type = phone.Type;
        Number = phone.Number;
        ProviderId = phone.ProviderId;
    }
}