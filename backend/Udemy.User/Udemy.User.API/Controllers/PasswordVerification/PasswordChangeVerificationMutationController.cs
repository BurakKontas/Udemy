using HotChocolate;
using HotChocolate.Types;
using Udemy.Common.Result;
using Udemy.Common.Security.PermissionAuthorizeAttribute;
using Udemy.User.API.Contracts.Requests;

namespace Udemy.User.API.Controllers.PasswordVerification;

[MutationType]
[GraphQLName("Password Change Verification Mutation")]
public class PasswordChangeVerificationMutationController
{
    public async Task<Result> CreatePasswordChangeVerificationRequest(PasswordChangeVerificationRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> VerifyPasswordChangeVerificationCode(PasswordChangeVerificationCodeRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [PermissionAuthorize(permissions: [Permissions.Administer, Permissions.Delete], mode: PermissionMode.Any)]
    public async Task<Result> DeletePasswordChangeVerificationRequest(DeletePasswordChangeVerificationRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}