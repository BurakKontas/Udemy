using HotChocolate;
using HotChocolate.Types;
using MassTransit;
using Udemy.Common.Security.PermissionAuthorizeAttribute;
using Udemy.User.Domain.Entities;

namespace Udemy.User.API.Controllers;

[MutationType]
public class UserMutationController(IBus bus)
{
    private readonly IBus _bus = bus;

    [GraphQLName("TestMutation")]
    //[PermissionAuthorize(permissions: [Permissions.Read], mode: PermissionMode.Any)]
    public async Task<string> TestMutation(string name, CancellationToken cancellationToken)
    {
        var requestClient = _bus.CreateRequestClient<TestEvent>();

        var (successResponse, faultResponse) = await requestClient.GetResponse<TestResultEvent, Fault<TestResultEvent>>(new TestEvent(name), cancellationToken);

        if (successResponse.IsCompletedSuccessfully)
        {
            var responseMessage = await successResponse;
            return $"Hello from Test to {responseMessage.Message.Result}";
        }
        else
        {
            var responseMessage = await faultResponse;
            return $"Failed: {responseMessage.Message.Message.Result}";
        }
    }
}
