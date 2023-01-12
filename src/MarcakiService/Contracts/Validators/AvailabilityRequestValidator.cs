using FluentValidation;

namespace MarcakiService.Application.Contracts.Validators;

public class AvailabilityRequestValidator : AbstractValidator<AvailabilityRequest>
{
    public AvailabilityRequestValidator()
    {
        RuleFor(x => x.Monday).NotEmpty();
        RuleFor(x => x.Thursday).NotEmpty();
        RuleFor(x => x.Tuesday).NotEmpty();
        RuleFor(x => x.Wednesday).NotEmpty();
        RuleFor(x => x.Friday).NotEmpty();
        RuleFor(x => x.Saturday);
        RuleFor(x => x.Friday);
    }
}