using MarcakiService.Domain.Commands;
using MarcakiService.Domain.Entities.ValueObjects;
using MarcakiService.Domain.Enums;

namespace MarcakiService.Domain.Entities.Aggregates;

public class Provider : AggregateRoot
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
    public string ActivationDate { get; set; }
    public DateTime BlockedDate { get; set; }
    public DateTime CreationDate { get; set; }
    public string BlockedReason { get; set; }

    public Provider()
    {
        
    }
    
    public Provider(CreateProvider request)
    {
        Name = request.Name;
        Email = request.Email;
        Document = request.Document;
        Phones = request.Phones;
        Address = request.Address;
        Employees = request.Employees;
        Services = request.Services;
        Availability = request.Availability;
        Status = request.Status;
        CreationDate = request.CreationDate;
    }
}