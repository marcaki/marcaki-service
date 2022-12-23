using System.Collections.Generic;
using FluentValidation.Results;

namespace MarcakiService.Application.Contracts.Responses;

public class InvalidRequestResponse
{
    public List<Error> Errors { get; set; }

    public InvalidRequestResponse(ValidationResult validationResult)
    {
        Errors = new List<Error>();
        foreach (var error in validationResult.Errors)
        {
            Errors.Add(new Error(error.PropertyName, error.ErrorMessage));
        }
    }
}

public class Error
{
    public string PropertyName { get; set; }
    public string ErrorMessage { get; set; }

    public Error(string propertyName, string errorMessage)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
    }
}