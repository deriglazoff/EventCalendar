namespace EventCalendar.Api.Domain;
public class NotificationCommand
{
    public EventModel EventModel { get; set; }

    public NotificationCommand(EventModel eventModel)
    {
        EventModel = eventModel;
    }

    public void Execute()
    {
        Console.WriteLine("sd");
    }
}
