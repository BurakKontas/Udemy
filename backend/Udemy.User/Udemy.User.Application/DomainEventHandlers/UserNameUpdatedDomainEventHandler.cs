using MassTransit;
using Udemy.User.Domain.Entities.User.DomainEvents;

namespace Udemy.User.Application.DomainEventHandlers;

public class UserNameUpdatedDomainEventHandler : IConsumer<UserNameUpdatedDomainEvent>
{
    public async Task Consume(ConsumeContext<UserNameUpdatedDomainEvent> context)
    {
        // log that name is updated
    }
}