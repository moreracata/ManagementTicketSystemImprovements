using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketManagement.Models
{
    public class RecordsListViewModel
    {
        public List<Ticket> Tickets { get; set; }
        public Paginator paginatior { get; set; }
    }
}