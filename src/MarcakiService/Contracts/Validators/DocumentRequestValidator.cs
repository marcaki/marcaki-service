using FluentValidation;
using MarcakiService.Application.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MarcakiService.Application.Contracts.Validators;

public class DocumentRequestValidator : AbstractValidator<DocumentRequest>
{
    public DocumentRequestValidator()
    {
        RuleFor(x => x.Type).NotEmpty().ChildRules(x =>
        {
            x.RuleFor(x => x).Must(x => x == "CPF" || x == "CNPJ");
        });

        RuleFor(x => x.Number).NotEmpty().Length(11, 14);
    }


}