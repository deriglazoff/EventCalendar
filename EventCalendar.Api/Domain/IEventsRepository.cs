namespace EventCalendar.Api.Domain;

public interface IEventsRepository
{
    public IEnumerable<EventEntity> GetEvent();
    public void AddEvent(EventEntity eventModel);

    public void UpdateEvent(EventEntity eventModel);
}
