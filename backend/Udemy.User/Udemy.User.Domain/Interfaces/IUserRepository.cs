using Udemy.Common.Result;

namespace Udemy.User.Domain.Interfaces;

public interface IUserRepository
{
    Task<Result<Entities.User.User>> GetUserByEmailAsync(string email);
    Task<Result<Entities.User.User>> GetUserByIdAsync(Guid userId);
    Task<Result<IEnumerable<Entities.User.User>>> GetAllUsersAsync();
    Task<Result> AddUserAsync(Entities.User.User user);
    Task<Result> UpdateUserAsync(Entities.User.User user);
    Task<Result> DeleteUserAsync(Guid userId);
}