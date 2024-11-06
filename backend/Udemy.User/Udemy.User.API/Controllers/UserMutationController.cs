using HotChocolate;
using HotChocolate.Types;
using Microsoft.AspNetCore.Authorization;
using Udemy.User.Infrastructure.PermissionAuthorizeAttribute;

namespace Udemy.User.API.Controllers;

[MutationType]
public class UserMutationController()
{
    [GraphQLName("TestMutation")]
    [PermissionAuthorize(permissions: [Permissions.Read], mode: PermissionMode.Any)]
    public async Task<string> TestMutation(string name, CancellationToken cancellationToken)
    {

        return $"Hello from Test to {name}";
    }
}
