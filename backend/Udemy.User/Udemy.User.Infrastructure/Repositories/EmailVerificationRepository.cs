using Udemy.Common.Result;
using Udemy.User.Domain.Entities.Verification;
using Udemy.User.Domain.Entities.Verification.ValueObjects;
using Udemy.User.Domain.Interfaces;
using Udemy.User.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Udemy.User.Infrastructure.Repositories;

public class EmailVerificationRepository(ApplicationContext context) : IEmailVerificationRepository
{
    private readonly ApplicationContext _context = context;
    private const int ExpirationTime = 15;

    public async Task<Result<EmailVerification>> CreateEmailVerificationRequestAsync(string email)
    {
        var expirationTime = DateTime.Now.AddMinutes(ExpirationTime);
        var emailVerification = EmailVerification.Create(email, expirationTime).Value;
        await _context.EmailVerifications.AddAsync(emailVerification);
        await _context.SaveChangesAsync();
        return Result<EmailVerification>.Success(emailVerification);
    }

    // Verify email using EmailOneTimeCode
    public async Task<Result> VerifyEmailAsync(VerificationId verificationId, EmailOneTimeCode code)
    {
        var emailVerification = await _context.EmailVerifications
            .FirstOrDefaultAsync(ev => ev.VerificationId.Id == verificationId.Id);

        if (emailVerification == null)
            return Result.Failure("Email verification request not found.");

        var result = emailVerification.Verify(code);
        if (result.IsFailure)
            return result;

        _context.EmailVerifications.Update(emailVerification);
        await _context.SaveChangesAsync();
        return Result.Success();
    }

    // Verify email using EmailVerificationCode
    public async Task<Result> VerifyEmailAsync(VerificationId verificationId, EmailVerificationCode code)
    {
        var emailVerification = await _context.EmailVerifications
            .FirstOrDefaultAsync(ev => ev.VerificationId.Id == verificationId.Id);

        if (emailVerification == null)
            return Result.Failure("Email verification request not found.");

        var result = emailVerification.Verify(code);
        if (result.IsFailure)
            return result;

        _context.EmailVerifications.Update(emailVerification);
        await _context.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> DeleteEmailVerificationRequestAsync(Guid verificationId)
    {
        var emailVerification = await _context.EmailVerifications
            .FirstOrDefaultAsync(ev => ev.VerificationId.Id == verificationId.ToString());

        if (emailVerification == null)
            return Result.Failure("Email verification request not found.");

        _context.EmailVerifications.Remove(emailVerification);
        await _context.SaveChangesAsync();
        return Result.Success();
    }
}