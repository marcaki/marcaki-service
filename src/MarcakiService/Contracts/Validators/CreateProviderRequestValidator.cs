using FluentValidation;

namespace MarcakiService.Application.Contracts.Validators;

public class CreateProviderRequestValidator : AbstractValidator<CreateProviderRequest>
{
    public CreateProviderRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.DocumentRequest).NotEmpty();
        RuleFor(x => x.Phones).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.Employees).NotEmpty();
        RuleFor(x => x.Services).NotEmpty();
        RuleForEach(x => x.Availability).NotEmpty().SetValidator(new AvailabilityRequestValidator());
        RuleFor(x => x.Status).NotEmpty();
        RuleFor(x => x.ActivationDate).NotEmpty();
        RuleFor(x => x.BlockedDate).NotEmpty();
        RuleFor(x => x.CreationDate).NotEmpty();
        RuleFor(x => x.BlockedReason).NotEmpty();
    }
}