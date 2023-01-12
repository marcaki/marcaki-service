using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace MarcakiService.Application.Contracts.Validators;

public class PhonesRequestValidator : AbstractValidator<PhoneRequest>
{
    public PhonesRequestValidator()
    {
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.Number).NotEmpty();
        RuleFor(x => x.Number).Must(IsValidPhone);
    }
    
    public bool IsValidPhone(string number)
    {
        RegularExpressionAttribute regex = new(@"^\d{2}[\s-]?[\s9]?\d{4}\d{4}$");
        return regex.IsValid(number);
    }
}