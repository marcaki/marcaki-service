using FluentValidation;
using MarcakiService.Application.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MarcakiService.Application.Contracts.Validators;

public class PhonesRequestValidator : AbstractValidator<PhoneRequest>
{
    public PhonesRequestValidator()
    {
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.Number).NotEmpty();
        RuleFor(x => x.Number).Must(IsValidPhone);
        RuleFor(x => x.Number).Must(CheckForSpecialCharacters);

    }


    public bool IsValidPhone(string number)
    {
        RegularExpressionAttribute regex = new(@"^\d{2}[\s-]?[\s9]?\d{4}\d{4}$");
        return regex.IsValid(number);

    }

    public bool CheckForSpecialCharacters(string number)
    {
        RegularExpressionAttribute regex = new(@"^(?=.*[@!#$%^&*()/\\])");
        return !regex.IsValid(number);
    }
}