using Microsoft.OpenApi.Writers;

namespace TicketingApp.Models.Dto.Posts
{
    public class EventPost
    {
        public int EventId { get; set; }
        public int VenueId { get; set; }
        public string Description { get; set; }
        public string? Name { get; set; }  = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
