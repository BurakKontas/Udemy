using System.Security.Cryptography;
using System.Text;
using Udemy.Common.Result;

namespace Udemy.User.Domain.Entities.User.ValueObjects;

public class Password
{
    public string Hash { get; }

    // Private constructor to ensure creation through Create method
    private Password(string hash)
    {
        Hash = hash;
    }

    // Create method to handle password creation with validation
    public static Result<Password> Create(string plainPassword)
    {
        if (string.IsNullOrWhiteSpace(plainPassword))
            return Result<Password>.Failure("Password cannot be empty.");

        var hash = HashPassword(plainPassword);
        return Result<Password>.Success(new Password(hash));
    }

    // Hashing password using SHA256
    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hashBytes = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hashBytes);
    }

    // Verify if the given plain password matches the stored hash
    public Result Verify(string plainPassword)
    {
        var isMatch = Hash == HashPassword(plainPassword);
        if (isMatch)
        {
            return Result.Success("Password is correct.");
        }
        return Result.Failure("Password is incorrect.");
    }
}
