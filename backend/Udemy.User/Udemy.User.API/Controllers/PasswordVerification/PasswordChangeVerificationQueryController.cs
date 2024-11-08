using HotChocolate;
using HotChocolate.Types;
using Udemy.Common.Result;
using Udemy.Common.Security.PermissionAuthorizeAttribute;
using Udemy.User.API.Contracts.Responses;
using Udemy.User.Domain.Entities.Verification;

namespace Udemy.User.API.Controllers.PasswordVerification;


[QueryType]
[GraphQLName("Password Change Verification Query")]
public class PasswordChangeVerificationQueryController
{
    // Get Password Change Verification Status
    [PermissionAuthorize(permissions: [Permissions.Administer, Permissions.View], mode: PermissionMode.Any)]
    public async Task<Result<PasswordChangeVerificationResponse>> GetPasswordChangeVerificationStatus(Guid verificationId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}