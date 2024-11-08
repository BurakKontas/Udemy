using Microsoft.EntityFrameworkCore;
using Udemy.Common.Result;
using Udemy.User.Domain.Interfaces;
using Udemy.User.Infrastructure.Context;

namespace Udemy.User.Infrastructure.Repositories;

public class UserRepository(ApplicationContext context) : IUserRepository
{
    private readonly ApplicationContext _context = context;

    public async Task<Result<Domain.Entities.User.User>> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        if (user == null)
            return Result<Domain.Entities.User.User>.Failure($"User with given email [{email}] does not exist.");

        return Result<Domain.Entities.User.User>.Success(user);
    }

    public async Task<Result<Domain.Entities.User.User>> GetUserByIdAsync(Guid userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
            return Result<Domain.Entities.User.User>.Failure($"User with ID [{userId}] does not exist.");

        return Result<Domain.Entities.User.User>.Success(user);
    }

    public async Task<Result<IEnumerable<Domain.Entities.User.User>>> GetAllUsersAsync()
    {
        var users = await _context.Users.ToArrayAsync();
        return Result<IEnumerable<Domain.Entities.User.User>>.Success(users);
    }

    public async Task<Result> AddUserAsync(Domain.Entities.User.User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> UpdateUserAsync(Domain.Entities.User.User user)
    {
        var existingUser = await _context.Users.FindAsync(user.Id);
        if (existingUser == null)
            return Result.Failure($"User with ID [{user.Id}] does not exist.");

        _context.Entry(existingUser).CurrentValues.SetValues(user);
        await _context.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> DeleteUserAsync(Guid userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
            return Result.Failure($"User with ID [{userId}] does not exist.");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return Result.Success();
    }
}