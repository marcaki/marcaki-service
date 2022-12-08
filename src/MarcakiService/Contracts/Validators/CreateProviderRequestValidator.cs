using FluentValidation;

namespace MarcakiService.Application.Contracts.Validators;

public class CreateProviderRequestValidator : AbstractValidator<CreateProviderRequest>
{
    public CreateProviderRequestValidator()
    {
        RuleForEach(x => x.Availability).NotEmpty().SetValidator(new AvailabilityRequestValidator());
    }
}