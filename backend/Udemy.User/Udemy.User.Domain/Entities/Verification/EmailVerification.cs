using Udemy.Common.Primitives;
using Udemy.Common.Result;
using Udemy.User.Domain.Entities.Verification.DomainEvents;
using Udemy.User.Domain.Entities.Verification.ValueObjects;

namespace Udemy.User.Domain.Entities.Verification;

public class EmailVerification : Entity
{
    public string Email { get; private set; }
    public VerificationId VerificationId { get; private set; }
    public EmailOneTimeCode EmailOneTimeCode { get; private set; }
    public EmailVerificationCode EmailVerificationCode { get; private set; }
    public DateTime ExpirationTime { get; private set; }
    public bool IsVerified { get; private set; }

    protected EmailVerification() { }

    private EmailVerification(string email, EmailOneTimeCode emailOneTimeCode, DateTime expirationTime, VerificationId verificationId, EmailVerificationCode emailVerificationCode)
    {
        Email = email;
        EmailOneTimeCode = emailOneTimeCode;
        ExpirationTime = expirationTime;
        VerificationId = verificationId;
        EmailVerificationCode = emailVerificationCode;
        IsVerified = false;
    }

    public static Result<EmailVerification> Create(string email, DateTime expirationTime)
    {
        var emailOneTimeCode = EmailOneTimeCode.Create().Value;
        var emailVerificationCode = EmailVerificationCode.Create().Value;
        var verificationId = VerificationId.Create().Value;

        var emailVerification = new EmailVerification(email, emailOneTimeCode, expirationTime, verificationId, emailVerificationCode);

        emailVerification.Arise(new EmailVerificationCreatedDomainEvent(Guid.NewGuid(), verificationId.Id));

        return Result<EmailVerification>.Success(emailVerification);
    }

    public Result Verify(EmailOneTimeCode oneTimeCode)
    {
        if (IsVerified)
            return Result.Failure("Email is already verified.");

        if (DateTime.UtcNow > ExpirationTime)
            return Result.Failure("Verification code has expired.");

        if (EmailOneTimeCode.Code != oneTimeCode.Code)
            return Result.Failure("Invalid verification code.");

        IsVerified = true;

        Arise(new EmailVerificationCreatedDomainEvent(Guid.NewGuid(), VerificationId.Id));

        return Result.Success();
    }

    public Result Verify(EmailVerificationCode verificationCode)
    {
        if (IsVerified)
            return Result.Failure("Email is already verified.");

        if (DateTime.UtcNow > ExpirationTime)
            return Result.Failure("Verification code has expired.");

        if (EmailVerificationCode.Code != verificationCode.Code)
            return Result.Failure("Invalid verification code.");

        IsVerified = true;

        Arise(new EmailVerificationCreatedDomainEvent(Guid.NewGuid(), VerificationId.Id));

        return Result.Success();
    }
}