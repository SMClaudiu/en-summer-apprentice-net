using System.Security.Cryptography.X509Certificates;

namespace TicketingApp.Models.Dto
{
    public class VenueDto
    {
        public int venueId {  get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
    }
}
