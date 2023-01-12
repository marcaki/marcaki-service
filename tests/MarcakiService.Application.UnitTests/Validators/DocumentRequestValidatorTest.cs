using FluentValidation.TestHelper;
using MarcakiService.Application.Contracts;
using MarcakiService.Application.Contracts.Validators;
using Xunit;

namespace MarcakiService.Application.UnitTests.Validators;

public class DocumentRequestValidatorTest
{
    private DocumentRequestValidator Validator { get; set; } = new();

    [Theory]
    [InlineData("CPR")]
    [InlineData("CNPR")]
    public void Validate_GivenAnInvalidType_ShouldHaveValidationError(string documentType)
    {
        var request = new DocumentRequest() { Type = documentType };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Type);
    }

    [Theory]
    [InlineData("CPF")]
    [InlineData("CNPJ")]
    public void Validate_GivenAValidType_ShouldNotHaveValidationError(string documentType)
    {
        var request = new DocumentRequest() { Type = documentType };

        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Type);
    }
    
    [Fact]
    public void Validate_GivenAnInvalidNumber_ShouldHaveValidationError()
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