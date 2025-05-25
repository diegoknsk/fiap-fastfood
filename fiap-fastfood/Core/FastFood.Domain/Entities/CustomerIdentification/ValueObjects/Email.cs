using FastFood.Domain.Common.Exceptions;
using System.Text.RegularExpressions;

namespace FastFood.Domain.Entities.CustomerIdentification.ValueObjects;

public class Email
{
    public string Value { get; private set; } = string.Empty;

    protected Email() { } // Requerido pelo EF Core

    public Email(string value)
    {
        DomainValidation.ThrowIfNullOrWhiteSpace(value, "Email is required.");

        if (!IsValidEmail(value))
            throw new DomainException("Invalid email address.");

        Value = value;
    }

    private bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    public override string ToString() => Value;
}