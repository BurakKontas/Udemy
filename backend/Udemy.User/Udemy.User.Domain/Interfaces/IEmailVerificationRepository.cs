using Udemy.Common.Result;
using Udemy.User.Domain.Entities.Verification;
using Udemy.User.Domain.Entities.Verification.ValueObjects;

namespace Udemy.User.Domain.Interfaces;

public interface IEmailVerificationRepository
{
    Task<Result<EmailVerification>> CreateEmailVerificationRequestAsync(string email);
    Task<Result> VerifyEmailAsync(VerificationId verificationId, EmailOneTimeCode code);
    Task<Result> VerifyEmailAsync(VerificationId verificationId, EmailVerificationCode code);
    Task<Result> DeleteEmailVerificationRequestAsync(Guid verificationId);
}