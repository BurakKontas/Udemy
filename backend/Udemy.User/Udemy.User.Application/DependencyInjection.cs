using HotChocolate.Types.Pagination;
using Microsoft.Extensions.DependencyInjection;
using Udemy.User.Application.Services;

namespace Udemy.User.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        DefineGraphQL(services);

        return services;
    }


    private static void DefineGraphQL(IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType()
                .AddTypeExtension<UserQueryService>()
            .AddMutationType()
                .AddTypeExtension<UserMutationService>()
            .ModifyPagingOptions(x =>
            {
                x.DefaultPageSize = 10;
            });
    }
}