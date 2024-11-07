using Microsoft.EntityFrameworkCore;

namespace Udemy.User.Infrastructure.Context;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    public DbSet<Domain.Entities.User.User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}