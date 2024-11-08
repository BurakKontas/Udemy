namespace Udemy.User.API.Contracts.Responses;

public record UserResponse(Guid UserId, string Email, string FullName);