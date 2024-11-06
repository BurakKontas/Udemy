using Microsoft.AspNetCore.Authorization;

namespace Udemy.User.Infrastructure.PermissionAuthorizeAttribute;

public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (requirement.Permissions.Length == 0)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        var hasAllPermissions = HasAllPermissions(context, requirement);

        if (hasAllPermissions) context.Succeed(requirement);
        else context.Fail();

        return Task.CompletedTask;
    }

    protected virtual bool HasAllPermissions(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        return requirement.Mode == PermissionMode.All
            ? requirement.Permissions.All(permission => context.User.HasClaim(c => c.Type == "Permission" && c.Value == permission.ToString()))
            : requirement.Permissions.Any(permission => context.User.HasClaim(c => c.Type == "Permission" && c.Value == permission.ToString()));
    }
}