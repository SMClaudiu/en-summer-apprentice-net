namespace TicketingApp.Models.Dto
{
    public class TicketCategoryDto
    {   
        public int ticketCategoryId { get; set; }

        public string? Description { get; set; }

        public float Price { get; set; }

        public virtual Event Event { get; set; }

    }
}
