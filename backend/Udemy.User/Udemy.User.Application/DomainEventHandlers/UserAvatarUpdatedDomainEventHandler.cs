using MassTransit;
using Udemy.User.Domain.Entities.User.DomainEvents;

namespace Udemy.User.Application.DomainEventHandlers;

public class UserAvatarUpdatedDomainEventHandler : IConsumer<UserAvatarUpdatedDomainEvent>
{
    public async Task Consume(ConsumeContext<UserAvatarUpdatedDomainEvent> context)
    {
        // log that avatar is changed
    }
}