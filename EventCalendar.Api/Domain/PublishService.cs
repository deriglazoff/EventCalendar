using MassTransit;

namespace EventCalendar.Api.Domain;

public class PublishService
{
    private readonly IEventsRepository _eventsRepository;

    private readonly IBus _bus;

    public PublishService(IEventsRepository eventsRepository, IBus bus)
    {
        _eventsRepository = eventsRepository;
        _bus = bus;
    }
    public async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (stoppingToken.IsCancellationRequested is false)
        {
            try
            {
                await Task.Delay(60_000, stoppingToken);
                var events = _eventsRepository.GetEvent();

                var needNotification = events.Where(x => x.IsNotification is false);

                foreach (var item in needNotification)
                {
                    await _bus.Publish(new NotificationCommand(item), stoppingToken);
                    item.IsNotification = true;
					_eventsRepository.UpdateEvent(item);
				}
            }
            catch (Exception ex)
            {
                var e = ex;
            }
        }
    }
}