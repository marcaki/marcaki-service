using System.Collections.Generic;
using FluentValidation.TestHelper;
using MarcakiService.Application.Contracts;
using MarcakiService.Application.Contracts.Validators;
using Xunit;

namespace MarcakiService.Application.UnitTests.Validators;

public class CreateProviderRequestValidatorTests
{
    private readonly CreateProviderRequestValidator _validator = new();
    
    [Fact]
    public void Validate_GivenAnInvalidName_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { Name = "" };

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void Validate_GivenAValidName_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { Name = "Mario Roberto" };

        var result = _validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void Validate_GivenAnInvalidEmail_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { Email = "" };

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void Validate_GivenAValidEmail_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { Email = "mario.costa@marcaki.com.br" };
        var result = _validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Email);
    }
    

    [Fact]
    public void Validate_GivenAnInvalidAddress_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { Address = new List<string>() };

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Address);
    }

    [Fact]
    public void Validate_GivenAValidAddress_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { Address = new List<string>() { "Rua a " } };
        var result = _validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Address);
    }

    [Fact]
    public void Validate_GivenAnInvalidServices_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { Services = "" };

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Services);
    }

    [Fact]
    public void Validate_GivenAValidServices_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { Services = "Serviço 1" };
        var result = _validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Services);
    }
}