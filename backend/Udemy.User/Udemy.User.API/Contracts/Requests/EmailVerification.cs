namespace Udemy.User.API.Contracts.Requests;

public record EmailVerificationRequest(string Email);
public record EmailVerificationCodeRequest(string VerificationId, string Code);
public record DeleteEmailVerificationRequest(string VerificationId);