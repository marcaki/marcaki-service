namespace MarcakiService.Domain.Entities.Projections;

public class AddressProjection : Projection
{
    public string Address { get; set; }
    
    public AddressProjection (){}

    public AddressProjection(string address)
    {
        Id = Guid.NewGuid().ToString();
        Address = address;
    }
}