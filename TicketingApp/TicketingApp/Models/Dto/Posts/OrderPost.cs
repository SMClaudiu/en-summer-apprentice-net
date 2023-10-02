    using Microsoft.Identity.Client;

    namespace TicketingApp.Models.Dto.Posts
    {
        public class OrderPost
        {   
            public int CustomerId { get; set; }
            public int ticketCategoryId { get; set; }
            public int numberOfTickets { get; set; }
        }
    }
