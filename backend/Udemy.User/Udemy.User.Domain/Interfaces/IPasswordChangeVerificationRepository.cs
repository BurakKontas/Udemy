using Udemy.Common.Result;
using Udemy.User.Domain.Entities.Verification;
using Udemy.User.Domain.Entities.Verification.ValueObjects;

namespace Udemy.User.Domain.Interfaces;

public interface IPasswordChangeVerificationRepository
{
    Task<Result<PasswordChangeVerification>> CreatePasswordChangeRequestAsync(string email);
    Task<Result> VerifyPasswordChangeTokenAsync(VerificationId tokenId, PasswordChangeVerificationCode token);
    Task<Result> DeletePasswordChangeRequestAsync(VerificationId tokenId);
}