using HotChocolate;
using HotChocolate.Types;
using Udemy.User.Infrastructure.PermissionAuthorizeAttribute;

namespace Udemy.User.API.Controllers;

[QueryType]
public class UserQueryController()
{
    [GraphQLName("TestQuery")]
    [PermissionAuthorize(permissions: [Permissions.Administer], mode: PermissionMode.Any)]
    public async Task<string> TestQuery(CancellationToken cancellationToken)
    {
        return "Hello from Test";
    }
}