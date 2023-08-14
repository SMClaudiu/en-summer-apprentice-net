using System;
using System.Collections.Generic;
using TicketingApp.Models.Dto;

namespace TicketingApp.Models;

public partial class Order
{   
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? TicketCategoryId { get; set; }

    public int? NumberOfTickets { get; set; }

    public DateTime? OrderedAt { get; set; } = System.DateTime.Now;

    public double? TotalPrice { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual TicketCategory? TicketCategory { get; set; }
}
