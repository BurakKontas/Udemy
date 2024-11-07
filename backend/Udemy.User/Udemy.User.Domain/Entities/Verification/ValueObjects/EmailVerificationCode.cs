using System.Security.Cryptography;
using Udemy.Common.Result;

namespace Udemy.User.Domain.Entities.Verification.ValueObjects;

public class EmailVerificationCode
{
    public string Code { get; private set; }

    private const int Length = 64;

    private EmailVerificationCode(string code) => Code = code;

    public static Result<EmailVerificationCode> Create()
    {
        var byteArray = new byte[Length * 3 / 4];
        RandomNumberGenerator.Fill(byteArray);

        var code = Convert.ToBase64String(byteArray)
            .TrimEnd('=')
            .Replace('+', 'A')
            .Replace('/', 'B');
        return Result<EmailVerificationCode>.Success(new EmailVerificationCode(code));
    }

    public static Result<EmailVerificationCode> Create(string code)
    {
        var isValid = Verify(code);
        if (!isValid)
            return Result<EmailVerificationCode>.Failure("Code is not valid.");

        return Result<EmailVerificationCode>.Success(new EmailVerificationCode(code));
    }

    private static bool Verify(string code)
    {
        return code.Length == Length && code.All(char.IsLetterOrDigit);
    }
}