using Udemy.Common.Result;

namespace Udemy.User.Domain.Entities.Verification.ValueObjects;

public class EmailOneTimeCode
{
    public string Code { get; set; }

    private const int Length = 6;

    private EmailOneTimeCode(string code) => Code = code;

    public static Result<EmailOneTimeCode> Create()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var code = new string(Enumerable.Repeat(chars, Length)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        return Result<EmailOneTimeCode>.Success(new EmailOneTimeCode(code));
    }

    public static Result<EmailOneTimeCode> Create(string code)
    {
        var isValid = Verify(code);
        if (!isValid)
            return Result<EmailOneTimeCode>.Failure("Code is not valid.");

        return Result<EmailOneTimeCode>.Success(new EmailOneTimeCode(code));
    }

    private static bool Verify(string code)
    {
        return code.Length == Length && code.All(c => char.IsUpper(c) || char.IsDigit(c));
    }
}