using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketManagement.Models
{
    public class TicketViewModel : Paginator
    {
        public List<Ticket> Tickets { get; set; }
        public Paginator Paginator { get; set; }
    }
}