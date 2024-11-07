using System.Security.Cryptography;
using Udemy.Common.Result;

namespace Udemy.User.Domain.Entities.Verification.ValueObjects;

public class PasswordChangeVerificationCode
{
    public string Code { get; private set; }

    private const int Length = 64;

    private PasswordChangeVerificationCode(string code) => Code = code;

    public static Result<PasswordChangeVerificationCode> Create()
    {
        var byteArray = new byte[Length * 3 / 4];
        RandomNumberGenerator.Fill(byteArray);

        var code = Convert.ToBase64String(byteArray)
            .TrimEnd('=')
            .Replace('+', 'A')
            .Replace('/', 'B');

        return Result<PasswordChangeVerificationCode>.Success(new PasswordChangeVerificationCode(code));
    }

    public static Result<PasswordChangeVerificationCode> Create(string code)
    {
        var isValid = Verify(code);
        if (!isValid)
            return Result.Failure<PasswordChangeVerificationCode>("Code is not valid.");

        return Result<PasswordChangeVerificationCode>.Success(new PasswordChangeVerificationCode(code));
    }

    private static bool Verify(string code)
    {
        return code.Length == Length && code.All(char.IsLetterOrDigit);
    }
}