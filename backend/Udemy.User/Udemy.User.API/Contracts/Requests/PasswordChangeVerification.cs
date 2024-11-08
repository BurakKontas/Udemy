namespace Udemy.User.API.Contracts.Requests;

public record PasswordChangeVerificationRequest(string Email);
public record PasswordChangeVerificationCodeRequest(string VerificationId, string Code);
public record DeletePasswordChangeVerificationRequest(string VerificationId);