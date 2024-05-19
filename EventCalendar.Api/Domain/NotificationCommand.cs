namespace EventCalendar.Api.Domain;
public class NotificationCommand
{
    public EventEntity EventModel { get; set; }

    public NotificationCommand(EventEntity eventModel)
    {
        EventModel = eventModel;
    }

    public void Execute()
    {
        Console.WriteLine("NotificationCommand");
    }
}
