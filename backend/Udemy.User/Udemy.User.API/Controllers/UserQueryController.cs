using HotChocolate;
using HotChocolate.Types;
using Udemy.Common.Security.PermissionAuthorizeAttribute;
using Udemy.User.Application.Interfaces;

namespace Udemy.User.API.Controllers;

[QueryType]
public class UserQueryController(IUserService userService)
{
    private readonly IUserService _userService = userService;

    [GraphQLName("TestQuery")]
    [PermissionAuthorize(permissions: [Permissions.Administer], mode: PermissionMode.Any)]
    public async Task<string> TestQuery(CancellationToken cancellationToken)
    {
        return "Hello from Test";
    }
}