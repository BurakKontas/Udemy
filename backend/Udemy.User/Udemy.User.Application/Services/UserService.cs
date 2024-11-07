using Udemy.User.Application.Interfaces;
using Udemy.User.Domain.Interfaces;

namespace Udemy.User.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task Method(CancellationToken cancellationToken)
    {

    }
}