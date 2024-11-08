namespace Udemy.User.API.Contracts.Responses;

public record PasswordChangeVerificationResponse(string VerificationId, string Email, bool IsVerified);
