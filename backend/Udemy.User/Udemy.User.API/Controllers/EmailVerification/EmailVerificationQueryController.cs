using HotChocolate;
using HotChocolate.Types;
using Udemy.Common.Result;
using Udemy.Common.Security.PermissionAuthorizeAttribute;
using Udemy.User.API.Contracts.Responses;

namespace Udemy.User.API.Controllers.EmailVerification;


[QueryType]
[GraphQLName("Email Verification Query")]
public class EmailVerificationQueryController
{
    // Get Email Verification Status
    [PermissionAuthorize(permissions: [Permissions.Administer, Permissions.View], mode: PermissionMode.Any)]
    public async Task<Result<EmailVerificationResponse>> GetEmailVerificationStatus(Guid verificationId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}