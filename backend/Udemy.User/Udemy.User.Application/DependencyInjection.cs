using HotChocolate.Types.Pagination;
using Microsoft.Extensions.DependencyInjection;
using Udemy.User.Application.Interfaces;
using Udemy.User.Application.Services;

namespace Udemy.User.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}