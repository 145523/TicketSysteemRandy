using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSysteem.Models
{
    /// <summary>
    /// Een Applicatie wordt beheerd door een Medewerker.
    /// Een Applicatie kan worden genomend op nul of meer Tickets.
    /// </summary>
    public class Applicatie
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// De naam van de Applicatie (verplicht)
        /// </summary>
        [Required]
        public string Naam { get; set; }

        /// <summary>
        /// De Foreign Key voor Beheerder
        /// </summary>
        [ForeignKey("Beheerder")]
        public int BeheerderId { get; set; }

        /// <summary>
        /// De Medewerker die de Applicatie beheert
        /// </summary>
        public Medewerker Beheerder { get; set; }

        /// <summary>
        /// Voor een Applicate kunnen nul of meer Ticket zijn ingelegd
        /// <para>Navigatieproperty</para>
        /// </summary>
        public ICollection<Ticket> Tickets { get; set; }
    }
}