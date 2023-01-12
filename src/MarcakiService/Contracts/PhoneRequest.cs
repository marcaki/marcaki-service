using System;
using MarcakiService.Domain.Entities.ValueObjects;

namespace MarcakiService.Application.Contracts;

public class PhoneRequest
{
    public string Type { get; set; }
    public string Number { get; set; }

    public Phone ToDomain(string providerId)
    {
        return new Phone(Guid.NewGuid().ToString(), providerId, Type, Number);
    }
}