using MassTransit;
using Microsoft.EntityFrameworkCore;
using Udemy.Common.Primitives;

namespace Udemy.User.Infrastructure.Context;

public class UserContext(DbContextOptions<UserContext> options, IPublishEndpoint publishEndpoint) : DbContext(options)
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public DbSet<Domain.Entities.User.User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);
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