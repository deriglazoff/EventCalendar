using EventCalendar.Api.Controller;

public class EventsRepository
{
    private readonly List<EventModel> _items;
    public EventsRepository() {
        _items = new List<EventModel>()
            {
                new EventModel() { Id = Guid.NewGuid(), Name = "Dally", Date = DateTime.Now.Date.AddHours(7)},
                new EventModel() { Id = Guid.NewGuid(), Name = "Dally", Date = DateTime.Now.Date.AddHours(8)},
                new EventModel() { Id = Guid.NewGuid(), Name = "Dally", Date = DateTime.Now.Date.AddHours(9)},
            };
    }
    public List<EventModel> GetEvent()
    {
        return _items;
    }
    public void AddEvent()
    {
        _items.Add(new EventModel() { Id = Guid.NewGuid(), Name = "Retro" });
    }

    public void UpdateEvent(EventModel eventModel)
    {
        var item = _items.First(x => x.Id == eventModel.Id);
        _items.Remove(item);
        _items.Add(eventModel);
    }
}