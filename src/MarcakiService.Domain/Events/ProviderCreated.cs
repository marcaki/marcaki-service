using MarcakiService.Domain.Commands;
using MarcakiService.Domain.Entities.ValueObjects;
using MarcakiService.Domain.Enums;

namespace MarcakiService.Domain.Events;

public class ProviderCreated : BaseEvent
{
    public string Name { get; set; }
    public Document Document { get; set; }
    public List<Phone> Phones { get; set; }
    public string Email { get; set; }
    public List<string> Address { get; set; }
    public List<string> Employees { get; set; }
    public List<string> Services { get; set; }
    public List<Availability> Availability { get; set; }
    public Status Status { get; set; }
    public DateTime CreationDate { get; set; }

    public sealed override int AggregateVersion { get; set; }

    public ProviderCreated(CreateProvider command) : base()
    {
        Name = command.Name;
        Document = command.Document;
        Phones = command.Phones;
        Email = command.Email;
        Address = command.Address;
        Employees = command.Employees;
        Services = command.Services;
        Availability = command.Availability;
        Status = command.Status;
        CreationDate = command.CreationDate;
        AggregateVersion = 1;
    }
}