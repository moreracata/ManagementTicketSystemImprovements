using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketManagement.Models
{
    public class Paginator
    {
        public int CurrentPage { get; set; }
        public int AmmountOfRecords { get; set; }
        public int RecordsByPage { get; set; }
    }
}