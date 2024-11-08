using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Udemy.Common.Primitives;
using Udemy.User.Domain.Entities.Verification;

namespace Udemy.User.Infrastructure.Context;

public class ApplicationContext : DbContext
{
    private readonly IPublishEndpoint _publishEndpoint;

    public ApplicationContext(DbContextOptions<ApplicationContext> options, IPublishEndpoint publishEndpoint) : base(options)
    {
        _publishEndpoint = publishEndpoint;
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<Domain.Entities.User.User> Users { get; set; }
    public DbSet<EmailVerification> EmailVerifications { get; set; }
    public DbSet<PasswordChangeVerification> PasswordChangeVerifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await DispatchDomainEvents(cancellationToken);
        return await base.SaveChangesAsync(cancellationToken);
    }

    private async Task DispatchDomainEvents(CancellationToken cancellationToken)
    {
        var entitiesWithEvents = ChangeTracker.Entries<Entity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity)
            .ToList();

        foreach (var entity in entitiesWithEvents)
        {
            foreach (var domainEvent in entity.DomainEvents)
            {
                await _publishEndpoint.Publish(domainEvent, cancellationToken);
            }

            entity.ClearDomainEvents();
        }
    }
}