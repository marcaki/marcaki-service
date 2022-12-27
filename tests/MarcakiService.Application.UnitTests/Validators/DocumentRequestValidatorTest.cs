using System.Collections.Generic;
using FluentValidation.TestHelper;
using MarcakiService.Application.Contracts;
using MarcakiService.Application.Contracts.Validators;
using Xunit;

namespace MarcakiService.Application.UnitTests.Validators;

public class DocumentRequestValidatorTest
{
    private DocumentRequestValidator Validator { get; set; } = new();

    [Fact]
    public void Validate_GivenAnInvalidType_ShouldHaveValidationError()
    {
        var request = new DocumentRequest() { Type = "" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Type);
    }

    [Fact]
    public void Validate_GivenAValidType_ShouldNotHaveValidationError()
    {
        var request = new DocumentRequest() { Type = "CPF" };

        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Type);
    }

    [Fact]
    public void Validate_GivenAInvalidNumber_ShouldHaveValidationError()
    {
        var request = new DocumentRequest() { Number = "" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Number);
    }

    [Fact]
    public void Validate_GivenAValidNumber_ShouldNotHaveValidationError()
    {
        var request = new DocumentRequest() { Number = "11111111111" };

        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Number);
    }


}