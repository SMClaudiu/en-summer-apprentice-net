using AutoMapper.Configuration.Conventions;

namespace TicketingApp.Models.Dto
{
    public class EventDto2
    {
        public int eventId { get; set; }
        public String eventName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
