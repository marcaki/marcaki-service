using System;
using System.Collections.Generic;
using System.Linq;
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
    public string Services { get; set; }
    public List<AvailabilityRequest> Availability { get; set; }

    public ValidationResult Validate()
    {
        return new CreateProviderRequestValidator().Validate(this);
    }

    public CreateProvider GetCommand()
    {
        var aggregateId = Guid.NewGuid().ToString();
        return new CreateProvider(
            aggregateId,
            Name,
            Document.ToDomain(),
            Phones.Select(x => x.ToDomain(aggregateId)).ToList(),
            Email,
            Address,
            Services,
            Availability.Select(x => x.ToDomain()).ToList());
    }
}