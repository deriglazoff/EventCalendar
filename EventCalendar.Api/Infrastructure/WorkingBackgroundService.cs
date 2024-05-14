using EventCalendar.Api.Domain;

namespace EventCalendar.Api.Infrastructure;
public class WorkingBackgroundService : BackgroundService
{

    private PublishService _publishService;
    public WorkingBackgroundService(PublishService publishService)
    {
        _publishService = publishService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _publishService.ExecuteAsync(stoppingToken);
    }
}
