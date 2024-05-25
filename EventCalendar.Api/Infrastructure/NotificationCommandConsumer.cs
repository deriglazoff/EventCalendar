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

	public async Task Consume(ConsumeContext<NotificationCommand> context)
	{
		await Task.Delay(5_000, context.CancellationToken);
		context.Message.Execute();
	}
}