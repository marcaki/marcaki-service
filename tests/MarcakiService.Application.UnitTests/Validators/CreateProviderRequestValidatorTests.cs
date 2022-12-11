using FluentValidation.TestHelper;
using MarcakiService.Application.Contracts;
using MarcakiService.Application.Contracts.Validators;
using Xunit;

namespace MarcakiService.Application.UnitTests.Validators;

public class CreateProviderRequestValidatorTests
{
    private CreateProviderRequestValidator Validator { get; set; } = new();

    // [Fact]
    // public void Validate_GivenAnInvalidId_ShouldHaveValidationError()
    // {
    //     var request = new CreateProviderRequest(){Id = ""};
    //
    //     var result = Validator.TestValidate(request);
    //     result.ShouldHaveValidationErrorFor(x => x.Id);
    // }
}