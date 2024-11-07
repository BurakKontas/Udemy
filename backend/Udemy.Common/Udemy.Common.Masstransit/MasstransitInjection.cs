using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Udemy.Common.Masstransit;

public static class MasstransitInjection
{
    public static void DefineMassTransit(IServiceCollection services, string connectionString, Assembly assembly)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.AddConsumers(assembly);

            busConfigurator.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(connectionString);

                cfg.UseInMemoryOutbox(context);

                cfg.ConfigureEndpoints(context);
            });
        });
    }
}