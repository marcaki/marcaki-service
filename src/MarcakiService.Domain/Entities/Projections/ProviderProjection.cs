using MarcakiService.Domain.Entities.ValueObjects;
using MarcakiService.Domain.Enums;
using MarcakiService.Domain.Events.Provider;

namespace MarcakiService.Domain.Entities.Projections;

public class ProviderProjection : Projection
{
    public string Name { get; set; }
    public string DocumentNumber { get; set; }
    public string DocumentType { get; set; }
    public List<PhoneProjection> Phones { get; set; }
    public string Email { get; set; }
    public List<AddressProjection> Address { get; set; }
    public string Services { get; set; }
    public List<Availability> Availability { get; set; }
    public Status Status { get; set; }
    public string ActivationDate { get; set; }
    public DateTime BlockedDate { get; set; }
    public DateTime CreationDate { get; set; }
    public string BlockedReason { get; set; }

    public ProviderProjection()
    {
        
    }
    
    public ProviderProjection(ProviderCreated notification)
    {
        Id = notification.AggregateId;
        Name = notification.Name;
        DocumentNumber = notification.Document.Number;
        DocumentType = notification.Document.Type;
        // Phones = notification.Phones;
        Email = notification.Email;
        // Address = notification.Address;
        Services = notification.Services;
        Availability = notification.Availability;
        Status = notification.Status;
        CreationDate = notification.CreationDate;
    }
}