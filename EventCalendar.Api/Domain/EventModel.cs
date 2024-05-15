namespace EventCalendar.Api.Domain
{
    public record EventModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsNotification { get; set; }
    }
}
