using MarcakiService.Domain.Entities.Aggregates;
using MarcakiService.Domain.Entities.ValueObjects;
using MarcakiService.Domain.Enums;
using MediatR;

namespace MarcakiService.Domain.Commands;

public class CreateProvider : Command, IRequest<Provider>
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
    
    public CreateProvider(string name, Document document, List<Phone> phones, string email, List<string> address,
        List<string> employees, List<string> services, List<Availability> availability)
    {
        Name = name;
        Document = document;
        Phones = phones;
        Email = email;
        Address = address;
        Employees = employees;
        Services = services;
        Availability = availability;
        Status = Status.StandBy;
        CreationDate = DateTime.UtcNow.Date;
    }
}