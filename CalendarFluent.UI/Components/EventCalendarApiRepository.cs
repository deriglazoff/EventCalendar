using EventCalendar.Api.Domain;

namespace CalendarFluent.UI.Components;
public class EventCalendarApiRepository : IEventsRepository
{
	private HttpClient _httpClient;

	public EventCalendarApiRepository(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public void AddEvent(EventEntity eventModel)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<EventEntity> GetEvent()
	{
		return _httpClient.GetFromJsonAsync<IEnumerable<EventEntity>>("events").Result;
	}

	public void UpdateEvent(EventEntity eventModel)
	{
		throw new NotImplementedException();
	}
}