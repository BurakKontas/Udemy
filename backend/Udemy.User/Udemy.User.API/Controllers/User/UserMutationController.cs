using HotChocolate;
using HotChocolate.Types;
using MassTransit;
using Udemy.Common.Result;
using Udemy.Common.Security.PermissionAuthorizeAttribute;
using Udemy.User.API.Contracts.Requests;
using Udemy.User.Domain.Entities;

namespace Udemy.User.API.Controllers.User;

[MutationType]
[GraphQLName("User Mutation")]
public class UserMutationController
{
    // Create User
    [PermissionAuthorize(permissions: [Permissions.Administer, Permissions.Create], mode: PermissionMode.Any)]
    public async Task<Result> CreateUser(UserRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    // Update User
    [PermissionAuthorize(permissions: [Permissions.Administer, Permissions.Update], mode: PermissionMode.Any)]
    public async Task<Result> UpdateUser(UserRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    // Delete User
    [PermissionAuthorize(permissions: [Permissions.Administer, Permissions.Delete], mode: PermissionMode.Any)]
    public async Task<Result> DeleteUser(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}