using MassTransit;
using Udemy.User.Domain.Entities.Verification.DomainEvents;

namespace Udemy.User.Application.DomainEventHandlers;

public class EmailVerificationCreatedDomainEventHandler : IConsumer<EmailVerificationCreatedDomainEvent>
{
    public async Task Consume(ConsumeContext<EmailVerificationCreatedDomainEvent> context)
    {
        // send email to verificationId's email 
    }
}