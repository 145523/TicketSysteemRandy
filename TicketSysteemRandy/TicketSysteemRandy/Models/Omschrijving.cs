using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSysteemRandy.Models
{
    public class Omschrijving
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Ticket")]
        [Required]
        public int TicketId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumTijd { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Tekst { get; set; }
    }
}
