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

    [Theory]
    [InlineData("85989455043")]
    [InlineData("85990344400")]
    [InlineData("21985148263")]
    public void Validate_GivenAValidNumber_ShouldNotHaveValidationError(string number)
    {
        var request = new PhoneRequest() { Number = number};

        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Number);
    }

    [Theory]
    [InlineData("11111111111")]
    [InlineData("(11) 99999-9999")]
    [InlineData("ssssssssss")]
    [InlineData("")]
    public void Validate_GivenAnInvalidNumber_ShouldHaveValidationError2(string number)
    {
        var request = new PhoneRequest() { Number = number };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Number);
    }
}
