namespace EventCalendar.Api.Domain;

public interface IEventsRepository
{
    public IEnumerable<EventModel> GetEvent();
    public void AddEvent(EventModel eventModel);

    public void UpdateEvent(EventModel eventModel);
}
