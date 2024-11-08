using HotChocolate;
using HotChocolate.Types;
using Udemy.Common.Result;
using Udemy.Common.Security.PermissionAuthorizeAttribute;
using Udemy.User.API.Contracts.Requests;

namespace Udemy.User.API.Controllers.EmailVerification;

[MutationType]
[GraphQLName("Email Verification Mutation")]
public class EmailVerificationMutationController
{
    // Create Email Verification Request
    public async Task<Result> CreateEmailVerificationRequest(EmailVerificationRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    // Verify Email using EmailOneTimeCode
    public async Task<Result> VerifyEmailOneTimeCode(EmailVerificationCodeRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    // Verify Email using EmailVerificationCode
    public async Task<Result> VerifyEmailVerificationCode(EmailVerificationCodeRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    // Delete Email Verification Request
    [PermissionAuthorize(permissions: [Permissions.Administer, Permissions.Delete], mode: PermissionMode.Any)]
    public async Task<Result> DeleteEmailVerificationRequest(DeleteEmailVerificationRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}