using EventCalendar.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventCalendar.Api.Infrastructure;
public class EventsRepository : DbContext, IEventsRepository
{
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
	}
	public EventsRepository(DbContextOptions<EventsRepository> options)
		: base(options)
	{
		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
		_items = new List<EventEntity>()
		{
			new EventEntity() { Id = Guid.NewGuid(), Name = "Dally", Date = DateTime.Now.Date.AddHours(8)},
			new EventEntity() { Id = Guid.NewGuid(), Name = "Lunch", Date = DateTime.Now.Date.AddHours(13)},
			new EventEntity() { Id = Guid.NewGuid(), Name = "Dally", Date = DateTime.Now.Date.AddDays(1).AddHours(8)},
			new EventEntity() { Id = Guid.NewGuid(), Name = "Lunch", Date = DateTime.Now.Date.AddDays(1).AddHours(13)},
			new EventEntity() { Id = Guid.NewGuid(), Name = "Dally", Date = DateTime.Now.Date.AddDays(2).AddHours(8)},
			new EventEntity() { Id = Guid.NewGuid(), Name = "Lunch", Date = DateTime.Now.Date.AddDays(2).AddHours(13)},
			new EventEntity() { Id = Guid.NewGuid(), Name = "Dally", Date = DateTime.Now.Date.AddDays(3).AddHours(8)},
			new EventEntity() { Id = Guid.NewGuid(), Name = "Lunch", Date = DateTime.Now.Date.AddDays(3).AddHours(13)},
			new EventEntity() { Id = Guid.NewGuid(), Name = "Dally", Date = DateTime.Now.Date.AddDays(4).AddHours(8)},
			new EventEntity() { Id = Guid.NewGuid(), Name = "Lunch", Date = DateTime.Now.Date.AddDays(4).AddHours(13)},
			new EventEntity() { Id = Guid.NewGuid(), Name = "Retro", Date = DateTime.Now.Date.AddDays(4).AddHours(16)},
		};
	}
	public DbSet<EventEntity> Events { get; set; }

	public readonly List<EventEntity> _items;
	public EventsRepository()
	{

	}
	public IEnumerable<EventEntity> GetEvent()
	{
		return Events.AsNoTracking().ToList();
	}
	public void AddEvent(EventEntity eventModel)
	{
		Events.Add(eventModel);
		SaveChanges();
	}

	public void UpdateEvent(EventEntity eventModel)
	{
		var item = Events.First(x => x.Id == eventModel.Id);
		Events.Remove(item);
		Events.Add(eventModel);
		SaveChanges();
	}

}