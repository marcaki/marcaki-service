using MarcakiService.Domain.Commands;
using MarcakiService.Domain.Entities.ValueObjects;
using MarcakiService.Domain.Enums;
using Newtonsoft.Json;

namespace MarcakiService.Domain.Events.Provider;

public class ProviderCreated : BaseEvent
{
    public string Name { get; set; }
    public Document Document { get; set; }
    public List<Phone> Phones { get; set; }
    public string Email { get; set; }
    public List<string> Address { get; set; }
    public string Services { get; set; }
    public List<Availability> Availability { get; set; }
    public Status Status { get; set; }
    public DateTime CreationDate { get; set; }

    public ProviderCreated() : base()
    {
        
    }
    public ProviderCreated(CreateProvider command) : base(command.AggregateId)
    {
        Name = command.Name;
        Document = command.Document;
        Phones = command.Phones;
        Email = command.Email;
        Address = command.Address;
        Services = command.Services;
        Availability = command.Availability;
        Status = command.Status;
        CreationDate = command.CreationDate;
        AggregateVersion = 1;
        AggregateType = GetType()?.FullName?.Remove(0,29) ?? string.Empty;
    }
    
    public override string SerializePayload()
    {
        return JsonConvert.SerializeObject(this);
    }
}