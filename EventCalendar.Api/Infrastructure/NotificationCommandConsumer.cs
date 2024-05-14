using EventCalendar.Api.Domain;
using MassTransit;

namespace EventCalendar.Api.Infrastructure;

public class NotificationCommandConsumer :
    IConsumer<NotificationCommand>
{
    readonly ILogger<NotificationCommandConsumer> _logger;

    public NotificationCommandConsumer(ILogger<NotificationCommandConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<NotificationCommand> context)
    {
        context.Message.Execute();
        return Task.CompletedTask;
    }
}