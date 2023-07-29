﻿namespace TicketingApp.Models.Dto
{
    public class OrderDto
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
