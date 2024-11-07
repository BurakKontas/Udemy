using MassTransit;
using Udemy.User.Domain.Entities.Verification.DomainEvents;

namespace Udemy.User.Application.DomainEventHandlers;

public class EmailVerifiedDomainEventHandler : IConsumer<EmailVerifiedDomainEvent>
{
    public async Task Consume(ConsumeContext<EmailVerifiedDomainEvent> context)
    {
        // log that email is verified
    }
}