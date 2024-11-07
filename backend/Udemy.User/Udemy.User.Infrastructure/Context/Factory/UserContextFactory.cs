using MassTransit;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Udemy.User.Infrastructure.Context.Factory;

public class UserContextFactory : IDesignTimeDbContextFactory<UserContext>
{
    public UserContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
        optionsBuilder.UseNpgsql();

        return new UserContext(optionsBuilder.Options, null!);
    }
}