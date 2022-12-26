using FluentValidation;

namespace MarcakiService.Application.Contracts.Validators;

public class CreateProviderRequestValidator : AbstractValidator<CreateProviderRequest>
{
    public CreateProviderRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.DocumentRequest).NotEmpty().SetValidator(new DocumentRequestValidator());
        RuleForEach(x => x.Phones).NotEmpty().SetValidator(new PhonesRequestValidator());
        RuleFor(x => x.Email).NotEmpty();
        RuleForEach(x => x.Address).NotEmpty();
        RuleForEach(x => x.Employees).NotEmpty();
        RuleForEach(x => x.Services).NotEmpty();
        RuleForEach(x => x.Availability).NotEmpty().SetValidator(new AvailabilityRequestValidator());
        RuleFor(x => x.Status).NotEmpty();
        RuleFor(x => x.ActivationDate).NotEmpty();
        RuleFor(x => x.BlockedDate).NotEmpty();
        RuleFor(x => x.CreationDate).NotEmpty();
        RuleFor(x => x.BlockedReason).NotEmpty();
        
    }
}