using HotChocolate;
using HotChocolate.Types;
using Microsoft.AspNetCore.Authorization;
using Udemy.Common.Security.PermissionAuthorizeAttribute;
using Udemy.User.Application.Interfaces;
using Udemy.User.Infrastructure.PermissionAuthorizeAttribute;

namespace Udemy.User.API.Controllers;

[MutationType]
public class UserMutationController(IUserService userService)
{
    private readonly IUserService _userService = userService;

    [GraphQLName("TestMutation")]
    [PermissionAuthorize(permissions: [Permissions.Read], mode: PermissionMode.Any)]
    public async Task<string> TestMutation(string name, CancellationToken cancellationToken)
    {

        return $"Hello from Test to {name}";
    }
}
