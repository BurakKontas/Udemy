using MassTransit;
using Udemy.User.Domain.Entities.Verification.DomainEvents;

namespace Udemy.User.Application.DomainEventHandlers;

public class PasswordChangeVerificationCreatedDomainEventHandler : IConsumer<PasswordChangeVerificationCreatedDomainEvent>
{
    public async Task Consume(ConsumeContext<PasswordChangeVerificationCreatedDomainEvent> context)
    {
        // send email to verificationId's email
    }
}