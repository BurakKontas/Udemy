using MassTransit;
using Udemy.User.Domain.Entities.User.DomainEvents;

namespace Udemy.User.Application.DomainEventHandlers;

public class UserRoleAssignedDomainEventHandler : IConsumer<UserRoleAssignedDomainEvent>
{
    public async Task Consume(ConsumeContext<UserRoleAssignedDomainEvent> context)
    {
        // log that users assigned a new role
    }
}