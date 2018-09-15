using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketManagement.Models
{
    public class Ticket
    {
        [Key]
        [Display(Name = "No Ticket")]
        [DisplayName("No Ticket")]
        public int Id { get; set; }

        [Display(Name = "Autor")]
        [DisplayName("Autor")]
        public string AuthorID { get; set; }

        [Display(Name = "Destinario")]
        [DisplayName("Destinario")]
        public string RecepientID { get; set; }

       
        public int CategoryID { get; set; }

        [Display(Name = "Prioridad")]
        
        public int PriorityID { get; set; }

        [DisplayName("Estado")]
        public int StatusID { get; set; }

        [Display(Name = "Descripcion")]
        [DisplayName("Descripcion")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        public string Subject { get; set; }

        [Display(Name = "Fecha Creacion")]
        [DisplayName("Fecha Creacion")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Fecha Modificacion")]
        [DisplayName("Fecha Modificacion")]
        [DataType(DataType.DateTime)]
        public DateTime LastModificationDate { get; set; }

        [Display(Name = "Contenido")]
        [DisplayName("Contenido")]
        [StringLength(1000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.MultilineText)]
        public string Contenido { get; set; }


        [ForeignKey("AuthorID")]
        [DisplayName("Author")]
        [Display(Name = "Author")]
        public ApplicationUser UserAuthor { get; set; }

        [ForeignKey("RecepientID")]
        [DisplayName("Recepient")]
        [Display(Name = "Recepient")]
        public ApplicationUser UserRecepient { get; set; }

        [ForeignKey("CategoryID")]
        [DisplayName("Category")]
        [Display(Name = "Category")]
        public TicketCategory Category { get; set; }

        [ForeignKey("PriorityID")]
        [DisplayName("Priority")]
        [Display(Name = "Priority")]
        public TicketPriority Priority { get; set; }

        [ForeignKey("StatusID")]
        [DisplayName("Status")]
        [Display(Name = "Status")]
        public TicketStatus Status { get; set; }

    }
}