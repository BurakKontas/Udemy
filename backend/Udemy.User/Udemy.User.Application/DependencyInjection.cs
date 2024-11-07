using HotChocolate.Types.Pagination;
using Microsoft.Extensions.DependencyInjection;
using Udemy.User.Domain.Interfaces;

namespace Udemy.User.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}