using Udemy.Common.Primitives;
using Udemy.Common.Result;
using Udemy.User.Domain.Entities.Verification.DomainEvents;
using Udemy.User.Domain.Entities.Verification.ValueObjects;

namespace Udemy.User.Domain.Entities.Verification;

public class PasswordChangeVerification : Entity
{
    public string Email { get; private set; }
    public VerificationId VerificationId { get; private set; }
    public PasswordChangeVerificationCode PasswordChangeCode { get; private set; }
    public DateTime ExpirationTime { get; private set; }
    public bool IsVerified { get; private set; }

    protected PasswordChangeVerification() { }

    private PasswordChangeVerification(string email, PasswordChangeVerificationCode passwordChangeCode, DateTime expirationTime, VerificationId verificationId)
    {
        Email = email;
        PasswordChangeCode = passwordChangeCode;
        ExpirationTime = expirationTime;
        VerificationId = verificationId;
        IsVerified = false;
    }

    public static Result<PasswordChangeVerification> Create(string email, DateTime expirationTime)
    {
        var passwordChangeCode = PasswordChangeVerificationCode.Create().Value;
        var verificationId = VerificationId.Create().Value;

        var passwordChangeVerification = new PasswordChangeVerification(email, passwordChangeCode, expirationTime, verificationId);

        passwordChangeVerification.Arise(new PasswordChangeVerificationCreatedDomainEvent(Guid.NewGuid(), verificationId.Id));

        return Result<PasswordChangeVerification>.Success(passwordChangeVerification);
    }

    public Result Verify(PasswordChangeVerificationCode code)
    {
        if (IsVerified)
            return Result.Failure("Password change is already verified.");

        if (DateTime.UtcNow > ExpirationTime)
            return Result.Failure("Verification code has expired.");

        if (PasswordChangeCode.Code != code.Code)
            return Result.Failure("Invalid verification code.");

        IsVerified = true;

        Arise(new PasswordChangeVerifiedDomainEvent(Guid.NewGuid(), VerificationId.Id));

        return Result.Success();
    }
}