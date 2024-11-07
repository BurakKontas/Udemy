using MassTransit;
using Udemy.User.Domain.Entities.Verification.DomainEvents;

namespace Udemy.User.Application.DomainEventHandlers;

public class PasswordChangeVerifiedDomainEventHandler : IConsumer<PasswordChangeVerifiedDomainEvent>
{
    public async Task Consume(ConsumeContext<PasswordChangeVerifiedDomainEvent> context)
    {
        // log that password is changed
    }
}