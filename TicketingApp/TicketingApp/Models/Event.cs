﻿using System;
using System.Collections.Generic;
using TicketingApp.Models.Dto;

namespace TicketingApp.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int VenueId { get; set; }

    public int EventTypeId { get; set; }

    public string? Name { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }

    public virtual EventType? EventType { get; set; } = null!;

    public virtual ICollection<TicketCategory>? TicketCategories { get; set; } = new List<TicketCategory>();

    public virtual Venue? Venue { get; set; } = null!;
}
