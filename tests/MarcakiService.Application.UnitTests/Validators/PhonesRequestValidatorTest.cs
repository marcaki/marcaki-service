using FluentValidation.TestHelper;
using MarcakiService.Application.Contracts;
using MarcakiService.Application.Contracts.Validators;
using Xunit;

namespace MarcakiService.Application.UnitTests.Validators;

public class PhonesRequestValidatorTests
{
    private PhonesRequestValidator Validator { get; set; } = new();

    [Fact]
    public void Validate_GivenAnInvalidType_ShouldHaveValidationError()
    {
        var request = new PhoneRequest() { Type = "" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Type);
    }

    [Fact]
    public void Validate_GivenAValidType_ShouldNotHaveValidationError()
    {
        var request = new PhoneRequest() { Type = "Celular" };

        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Type);
    }

    [Fact]
    public void Validate_GivenAnInvalidNumber_ShouldHaveValidationError()
    {
        var request = new PhoneRequest() { Number = "" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Number);
    }

    [Fact]
    public void Validate_GivenAValidNumber_ShouldNotHaveValidationError()
    {
        var request = new PhoneRequest() { Number = "85999999999" };

        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Number);
    }

    [Fact]
    public void Validate_GivenAnNumber_WithTheInvalidAmountOfCharacters_MustHaveValidationError()
    {
        var request = new PhoneRequest() { Number = "8598611" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Number);
    }

    [Fact]
    public void Validate_GivenANumberWithSpecialCharacters_MustHaveValidationError()
    {
        var request = new PhoneRequest() { Number = "(11)99999-9999" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Number);
    }
}
