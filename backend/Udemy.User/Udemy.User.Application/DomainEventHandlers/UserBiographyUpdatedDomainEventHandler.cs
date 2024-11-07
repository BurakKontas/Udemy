using MassTransit;
using Udemy.User.Domain.Entities.User.DomainEvents;

namespace Udemy.User.Application.DomainEventHandlers;

public class UserBiographyUpdatedDomainEventHandler : IConsumer<UserBiographyUpdatedDomainEvent>
{
    public async Task Consume(ConsumeContext<UserBiographyUpdatedDomainEvent> context)
    {
        // log that biography is changed
    }
}