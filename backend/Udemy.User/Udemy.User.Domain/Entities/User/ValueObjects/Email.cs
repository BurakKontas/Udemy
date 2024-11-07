using System.Text.RegularExpressions;
using Udemy.Common.Result;

namespace Udemy.User.Domain.Entities.User.ValueObjects;

public class Email
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Result<Email> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            return Result<Email>.Failure("Invalid email address.");

        return Result<Email>.Success(new Email(value));
    }
}