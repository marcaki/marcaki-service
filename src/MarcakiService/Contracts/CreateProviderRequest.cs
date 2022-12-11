using FluentValidation.Results;
using MarcakiService.Application.Contracts.Validators;
using MarcakiService.Domain.Commands;

namespace MarcakiService.Application.Contracts;

public class CreateProviderRequest
{
    public string Name { get; set; }
    public DocumentRequest Document { get; set; }
    public List<PhoneRequest> Phones { get; set; }
    public string Email { get; set; }
    public List<string> Address { get; set; }
    public List<string> Employees { get; set; }
    public List<string> Services { get; set; }
    public List<AvailabilityRequest> Availability { get; set; }

    public ValidationResult Validate()
    {
        return new CreateProviderRequestValidator().Validate(this);
    }

    public CreateProvider GetCommand()
    {
        return new CreateProvider(
            Name,
            Document.ToDomain(),
            Phones.Select(x => x.ToDomain()).ToList(),
            Email,
            Address,
            Employees,
            Services,
            Availability.Select(x => x.ToDomain()).ToList());
    }
}