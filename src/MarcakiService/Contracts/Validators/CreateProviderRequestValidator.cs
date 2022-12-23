using FluentValidation;

namespace MarcakiService.Application.Contracts.Validators;

public class CreateProviderRequestValidator : AbstractValidator<CreateProviderRequest>
{
    public CreateProviderRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Document).NotEmpty();
        RuleFor(x => x.Phones).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.Services).NotEmpty();
        RuleForEach(x => x.Availability).NotEmpty().SetValidator(new AvailabilityRequestValidator());
    }
}