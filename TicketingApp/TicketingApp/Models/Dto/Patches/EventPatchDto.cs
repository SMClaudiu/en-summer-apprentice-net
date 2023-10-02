namespace TicketingApp.Models.Dto.Patches
{
    public class EventPatchDto
    {
        public int EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Description { get; set; } = string.Empty;

        public VenueDto venue { get; set; }

    }
}
