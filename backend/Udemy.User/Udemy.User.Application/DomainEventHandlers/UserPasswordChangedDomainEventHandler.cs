using MassTransit;
using Udemy.User.Domain.Entities.User.DomainEvents;

namespace Udemy.User.Application.DomainEventHandlers;

public class UserPasswordChangedDomainEventHandler : IConsumer<UserPasswordChangedDomainEvent>
{
    public async Task Consume(ConsumeContext<UserPasswordChangedDomainEvent> context)
    {
        // log that password is changed
    }
}