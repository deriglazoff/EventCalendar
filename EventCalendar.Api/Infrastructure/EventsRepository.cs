using EventCalendar.Api.Domain;

namespace EventCalendar.Api.Infrastructure;
public class EventsRepository: IEventsRepository
{
    private readonly List<EventModel> _items;
    public EventsRepository()
    {
        _items = new List<EventModel>()
        {
            new EventModel() { Id = Guid.NewGuid(), Name = "Dally", Date = DateTime.Now.Date.AddHours(7)},
            new EventModel() { Id = Guid.NewGuid(), Name = "Dally", Date = DateTime.Now.Date.AddHours(8)},
            new EventModel() { Id = Guid.NewGuid(), Name = "Dally", Date = DateTime.Now.Date.AddHours(9)},
        };
    }
    public IEnumerable<EventModel> GetEvent()
    {
        return _items;
    }
    public void AddEvent(EventModel eventModel)
    {
        _items.Add(eventModel);
    }

    public void UpdateEvent(EventModel eventModel)
    {
        var item = _items.First(x => x.Id == eventModel.Id);
        _items.Remove(item);
        _items.Add(eventModel);
    }

}