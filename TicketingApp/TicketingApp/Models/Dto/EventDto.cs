namespace TicketingApp.Models.Dto
{
    public class EventDto
    {

        public int EventId { get; set; }
        public int VenueId { get; set; }

        public int EventTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<TicketCategoryDto>? TicketCategories { get; set; } 
        public VenueDto? venue { get; set; }
        public EventType? EventType { get; set; } = null!;

    }
}
