using System;
using System.Collections.Generic;
using TicketingApp.Models.Dto;

namespace TicketingApp.Models;

public partial class EventType
{
    public int EventTypeId { get; set; }

    public string? Name { get; set; }

    //public ICollection<Event>? Events { get; set; } = new List<Event>();
}
