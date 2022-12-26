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
        RuleFor(x => x.Number).Must(ValidatePhone);

    }


   public bool ValidatePhone(string number)
    {
      RegularExpressionAttribute regex = new(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$");
        return regex.IsValid(number);

    }
}
