namespace TicketingApp.Models.Dto.Patches
{
    public class OrderPatchDto
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int? TicketCategoryId { get; set; }

        public int? NumberOfTickets { get; set; }

        public DateTime? OrderedAt { get; set; }

        public double? TotalPrice { get; set; }

        public CustomerDto customer { get; set; }
    }
}
