using Udemy.Common.Result;

namespace Udemy.User.Domain.Entities.User.ValueObjects;

public class Name
{
    public string Value { get; }

    private Name(string value)
    {
        Value = value;
    }

    public static Result<Name> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<Name>.Failure("Name cannot be empty.");

        return Result<Name>.Success(new Name(value));
    }
}