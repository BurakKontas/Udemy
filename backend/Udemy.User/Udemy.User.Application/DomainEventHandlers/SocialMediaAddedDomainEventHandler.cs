using MassTransit;
using Udemy.User.Domain.Entities.User.DomainEvents;

namespace Udemy.User.Application.DomainEventHandlers;

public class SocialMediaAddedDomainEventHandler : IConsumer<SocialMediaAddedDomainEvent>
{
    public async Task Consume(ConsumeContext<SocialMediaAddedDomainEvent> context)
    {
        // log that social media is added
    }
}