using MassTransit;
using Udemy.User.Domain.Entities.User.DomainEvents;

namespace Udemy.User.Application.DomainEventHandlers;

public class IdentityProviderAddedDomainEventHandler : IConsumer<IdentityProviderAddedDomainEvent>
{
    public async Task Consume(ConsumeContext<IdentityProviderAddedDomainEvent> context)
    {
        // log that provider is added
    }
}