using Udemy.User.API.Controllers.EmailVerification;
using Udemy.User.API.Controllers.PasswordVerification;
using Udemy.User.API.Controllers.User;

namespace Udemy.User.API;

public static class DependencyInjection
{
    public static IServiceCollection AddAPI(this IServiceCollection services)
    {
        DefineGraphQL(services);

        return services;
    }

    private static void DefineGraphQL(IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddAuthorization()
            .AddQueryType()
                .AddTypeExtension<UserQueryController>()
                .AddTypeExtension<EmailVerificationQueryController>()
                .AddTypeExtension<PasswordChangeVerificationQueryController>()
            .AddMutationType()
                .AddTypeExtension<UserMutationController>()
                .AddTypeExtension<EmailVerificationMutationController>()
                .AddTypeExtension<PasswordChangeVerificationMutationController>()
            .ModifyPagingOptions(x =>
            {
                x.DefaultPageSize = 10;
            });
    }
}