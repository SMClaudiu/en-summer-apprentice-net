using System;
using System.Collections.Generic;

namespace TicketingApp.Models;

public partial class TotalNumberOfTicketsPerCategory
{
    public int? CategorieTichet { get; set; }

    public int? NumarTotalBilete { get; set; }

    public decimal? CostTotalBilete { get; set; }
}
