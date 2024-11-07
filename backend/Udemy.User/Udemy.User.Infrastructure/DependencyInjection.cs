using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Udemy.Common.Masstransit;
using Udemy.Common.Security.AuthenticationHandlers;
using Udemy.Common.Security.PermissionAuthorizeAttribute;
using Udemy.User.Application;
using Udemy.User.Domain.Interfaces;
using Udemy.User.Infrastructure.Context;
using Udemy.User.Infrastructure.Repositories;

namespace Udemy.User.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        AddPermissionsAuthentication(services);
        DefineMassTransit(services, configuration);

        return services;
    }

    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        AddPostgres(builder);
        AddSeq(builder);

        return builder;
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

    private static void DefineMassTransit(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("rabbitmq");
        if (connectionString == null)
            throw new ArgumentNullException($"RabbitMQ connection string is not set.");

        MasstransitInjection.DefineMassTransit(services, connectionString, ApplicationAssembly.Assembly);
    }

    private static void AddPostgres(WebApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<UserContext>(connectionName: "userdb");
        builder.EnrichNpgsqlDbContext<UserContext>(
            configureSettings: settings =>
            {
                settings.DisableRetry = false;
                settings.CommandTimeout = 30;
            });
    }

    private static void AddSeq(WebApplicationBuilder builder)
    {
        builder.AddSeqEndpoint("seq");
    }
}