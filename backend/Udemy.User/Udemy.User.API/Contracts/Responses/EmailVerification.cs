namespace Udemy.User.API.Contracts.Responses;

public record EmailVerificationResponse(string VerificationId, string Email, bool IsVerified);