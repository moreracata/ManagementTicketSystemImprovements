using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketManagement.Models
{
    public class TicketCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Ticket> tickets;
    }
}