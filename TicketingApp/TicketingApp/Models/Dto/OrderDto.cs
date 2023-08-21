namespace TicketingApp.Models.Dto
{
    public class OrderDto
    {
        public int EventId { get; set; }
        public string eventName {get;set;}
        public int OrderId { get; set; } 
        public int? NumberOfTickets { get; set; }

        public DateTime? OrderedAt { get; set; }

        public double? TotalPrice { get; set; }

        public CustomerDto customer { get; set; }
        
        public virtual TicketCategoryDto? TicketCategory { get; set; }
    }
}
