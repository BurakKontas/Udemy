using Udemy.Common.Result;
using Udemy.User.Domain.Entities.Verification;
using Udemy.User.Domain.Entities.Verification.ValueObjects;
using Udemy.User.Domain.Interfaces;
using Udemy.User.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Udemy.User.Infrastructure.Repositories;

public class PasswordChangeVerificationRepository(ApplicationContext context) : IPasswordChangeVerificationRepository
{
    private readonly ApplicationContext _context = context;
    private const int ExpirationTime = 15;

    public async Task<Result<PasswordChangeVerification>> CreatePasswordChangeRequestAsync(string email)
    {
        var expirationTime = DateTime.UtcNow.AddMinutes(ExpirationTime);
        var creationResult = PasswordChangeVerification.Create(email, expirationTime);

        if (creationResult.IsFailure)
            return Result<PasswordChangeVerification>.Failure(creationResult.Message);

        var passwordChangeRequest = creationResult.Value;
        await _context.PasswordChangeVerifications.AddAsync(passwordChangeRequest);
        await _context.SaveChangesAsync();

        return Result<PasswordChangeVerification>.Success(passwordChangeRequest);
    }

    public async Task<Result> VerifyPasswordChangeTokenAsync(VerificationId tokenId, PasswordChangeVerificationCode token)
    {
        var verification = await _context.PasswordChangeVerifications
            .FirstOrDefaultAsync(p => p.VerificationId.Id == tokenId.Id);

        if (verification == null)
            return Result.Failure("Verification request not found.");

        var verifyResult = verification.Verify(token);
        if (verifyResult.IsFailure)
            return Result.Failure(verifyResult.Message);

        _context.PasswordChangeVerifications.Update(verification);
        await _context.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> DeletePasswordChangeRequestAsync(VerificationId tokenId)
    {
        var verification = await _context.PasswordChangeVerifications
            .FirstOrDefaultAsync(p => p.VerificationId.Id == tokenId.Id);

        if (verification == null)
            return Result.Failure("Verification request not found.");

        _context.PasswordChangeVerifications.Remove(verification);
        await _context.SaveChangesAsync();

        return Result.Success();
    }
}