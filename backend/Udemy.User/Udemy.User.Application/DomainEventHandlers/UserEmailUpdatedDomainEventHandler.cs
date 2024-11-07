using MassTransit;
using Udemy.User.Domain.Entities.User.DomainEvents;

namespace Udemy.User.Application.DomainEventHandlers;

public class UserEmailUpdatedDomainEventHandler : IConsumer<UserEmailUpdatedDomainEvent>
{
    public async Task Consume(ConsumeContext<UserEmailUpdatedDomainEvent> context)
    {
        // log that email is updated
    }
}