using System.Collections.Generic;
using FluentValidation.TestHelper;
using MarcakiService.Application.Contracts;
using MarcakiService.Application.Contracts.Validators;
using Xunit;

namespace MarcakiService.Application.UnitTests.Validators;

public class CreateProviderRequestValidatorTests
{
    private CreateProviderRequestValidator Validator { get; set; } = new();

    [Fact]
    public void Validate_GivenAnInvalidId_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { Id = "" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Id);
    }

    [Fact]
    public void Validate_GivenAValidId_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { Id = "161615" };
        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Id);
    }

    [Fact]

    public void Validate_GivenAInvalidName_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { Name = "" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void Validate_GivenAValidName_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { Name = "Mario Roberto" };

        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void Validate_GivenAInvalidEmail_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { Email = "" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void Validate_GivenAValidEmail_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { Email = "mario.costa@marcaki.com.br" };
        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Email);
    }
    

    [Fact]
    public void Validate_GivenAInvaliddAddress_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { Address = new List<string>() { "" } };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Address);
    }

    [Fact]
    public void Validate_GivenAValidAddress_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { Address = new List<string>() { "Rua a " } };
        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Address);
    }


    [Fact]
    public void Validate_GivenAInvalidEmployees_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { Employees = new List<string>() { "" } };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Employees);
    }

    [Fact]
    public void Validate_GivenAValidEmployees_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { Employees = new List<string>() { "Mario Roberto" } };
        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Employees);
    }

    [Fact]
    public void Validate_GivenAInvalidServices_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { Services = new List<string>() { "" } };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Services);
    }

    [Fact]
    public void Validate_GivenAValidServices_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { Services = new List<string>() { "Serviço 1" } };
        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Services);
    }

    [Fact]
    public void validate_GivenAInvalidStatus_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { Status = "" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Status);
    }

    [Fact] 
    public void validate_GivenAvalidateStatus_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { Status = "Ativo" };
        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Status);
    }

    [Fact]
    public void validate_GivenAInvalidActivationDate_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { ActivationDate = "" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.ActivationDate);
    }

    [Fact]
    public void validate_GivenAvalidateActivationDate_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { ActivationDate = "2020-01-01" };
        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.ActivationDate);
    }

    [Fact]
    public void validate_GivenAInvalidBlockedDate_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { BlockedDate = "" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.BlockedDate);
    }

    [Fact]
    public void validate_GivenAvalidateBlockedDate_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { BlockedDate = "2020-01-01" };
        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.BlockedDate);
    }

    [Fact]
    public void validate_GivenAInvalidBlockedReason_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { BlockedReason = "" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.BlockedReason);
    }

    [Fact]
    public void validate_GivenAvalidateBlockedReason_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { BlockedReason = "Motivo 1" };
        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.BlockedReason);
    }

    [Fact]
    public void validate_GivenAInvalidCreationDate_ShouldHaveValidationError()
    {
        var request = new CreateProviderRequest() { CreationDate = "" };

        var result = Validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.CreationDate);
    }

    [Fact]
    public void validate_GivenAvalidateCreationDate_ShouldNotHaveValidationError()
    {
        var request = new CreateProviderRequest() { CreationDate = "2020-01-01" };
        var result = Validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.CreationDate);
    }
    


}