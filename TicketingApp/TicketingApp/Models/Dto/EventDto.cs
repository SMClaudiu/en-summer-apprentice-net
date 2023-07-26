namespace TicketingApp.Models.Dto
{
    public class EventDto
    {
        public int EventId { get; set; }

        //public int VenueId { get; set; }
        //public int EventTypeId { get; set; }

        public string Name { get; set; } = string.Empty;
        //public DateTime StartDate { get; set; }

        public string Description { get; set; } = string.Empty;
        //        public EventType EventType { get; set; }
        //      public TicketCategory Category { get; set; }
        //    public Venue venue { get; set; }
    }
}
