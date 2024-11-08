namespace Udemy.User.API.Contracts.Requests;

public record UserRequest(string Email, string FullName, string Password);
public record DeleteUserRequest(Guid UserId);