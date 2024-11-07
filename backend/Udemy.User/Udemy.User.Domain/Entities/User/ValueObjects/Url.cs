using System.Text.RegularExpressions;
using Udemy.Common.Result;

namespace Udemy.User.Domain.Entities.User.ValueObjects;

public class Url
{
    public string Value { get; }

    private Url(string value)
    {
        Value = value;
    }

    private static readonly Regex UrlRegex = new(@"^(https?|ftp)://[^\s/$.?#].[^\s]*$", RegexOptions.IgnoreCase);

    public static Result<Url> Create(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return Result<Url>.Failure("URL cannot be empty.");

        if (!UrlRegex.IsMatch(url))
            return Result<Url>.Failure("Invalid URL format.");

        return Result<Url>.Success(new Url(url));
    }
}