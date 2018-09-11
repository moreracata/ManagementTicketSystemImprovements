using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketManagement.Models
{
    public class Paginador
    {
        public int CurrenPage { get; set; }
        public int AmmountOfRegisters { get; set; }
        public int RegistersByPage { get; set; }
    }
}