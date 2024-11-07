using Udemy.User.API.Controllers;

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
            .AddMutationType()
                .AddTypeExtension<UserMutationController>()
            .ModifyPagingOptions(x =>
            {
                x.DefaultPageSize = 10;
            });
    }
}