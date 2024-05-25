namespace EventCalendar.Api.Domain
{
	public record EventEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public bool IsNotification { get; set; }
	}
}
