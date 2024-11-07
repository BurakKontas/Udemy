
using HotChocolate.Authorization;

namespace Udemy.Common.Security.PermissionAuthorizeAttribute;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class PermissionAuthorizeAttribute : AuthorizeAttribute
{
    public PermissionAuthorizeAttribute(Permissions[]? permissions = null, PermissionMode mode = PermissionMode.Any)
    {
        permissions ??= [];
        Policy = $"PermissionPolicy?Permissions={string.Join(",", permissions)}&mode={mode}";
    }
}