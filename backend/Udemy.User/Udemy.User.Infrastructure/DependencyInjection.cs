using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Udemy.Common.Security.AuthenticationHandlers;
using Udemy.Common.Security.PermissionAuthorizeAttribute;
using Udemy.User.Domain.Interfaces;
using Udemy.User.Infrastructure.AuthenticationHandlers;
using Udemy.User.Infrastructure.PermissionAuthorizeAttribute;
using Udemy.User.Infrastructure.Repositories;

namespace Udemy.User.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        AddPermissionsAuthentication(services);

        return services;
    }

    private static void AddPermissionsAuthentication(IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionsAuthorizationPolicyProvider>();
        services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = "PermissionAuthentication";
        })
        .AddScheme<AuthenticationSchemeOptions, PermissionAuthenticationHandler>("PermissionAuthentication", options => { });
    }
}