using HotChocolate;
using HotChocolate.Types;
using Udemy.Common.Result;
using Udemy.Common.Security.PermissionAuthorizeAttribute;
using Udemy.User.API.Contracts.Responses;

namespace Udemy.User.API.Controllers.User;

[QueryType]
[GraphQLName("User Query")]
public class UserQueryController
{
    [PermissionAuthorize(permissions: [Permissions.Administer, Permissions.View], mode: PermissionMode.Any)]
    public async Task<Result<UserResponse>> GetUser(Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [PermissionAuthorize(permissions: [Permissions.Administer, Permissions.View], mode: PermissionMode.Any)]
    public async Task<Result<UserResponse>> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}