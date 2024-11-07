using System.Security.Cryptography;
using Udemy.Common.Result;

namespace Udemy.User.Domain.Entities.Verification.ValueObjects;

public class VerificationId
{
    public string Id { get; private set; }

    private const int Length = 64;

    private VerificationId(string id) => Id = id;

    public static Result<VerificationId> Create()
    {
        var byteArray = new byte[Length * 3 / 4];
        RandomNumberGenerator.Fill(byteArray);

        var code = Convert.ToBase64String(byteArray)
            .TrimEnd('=')
            .Replace('+', 'A')
            .Replace('/', 'B');
        return Result<VerificationId>.Success(new VerificationId(code));
    }

    public static Result<VerificationId> Create(string code)
    {
        var isValid = Verify(code);
        if (!isValid)
            return Result<VerificationId>.Failure("Code is not valid.");

        return Result<VerificationId>.Success(new VerificationId(code));
    }

    private static bool Verify(string code)
    {
        return code.Length == Length && code.All(char.IsLetterOrDigit);
    }
}