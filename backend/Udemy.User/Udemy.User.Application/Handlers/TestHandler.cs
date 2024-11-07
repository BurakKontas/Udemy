using MassTransit;
using Udemy.User.Domain.Entities;

namespace Udemy.User.Application.Handlers;

public class TestHandler(IBus bus) : IConsumer<TestEvent>
{
    public async Task Consume(ConsumeContext<TestEvent> context)
    {
        await context.RespondAsync(new TestResultEvent("Consumed " + context.Message.Message));
    }
}