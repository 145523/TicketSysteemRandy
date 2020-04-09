using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSysteem.Models
{
    /// <summary>
    /// Klanten kunnen Tickets inschieten met vragen over of problemen met een Applicatie
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Het Id van de Ticket
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// KlantId. Is de Foreign Key van de Klant
        /// </summary>
        [ForeignKey("Klant")]
        [Required]
        public int KlantId { get; set; }

        /// <summary>
        /// De Klant die de Ticket heeft ingelegd
        /// <para>NavigatieProperty</para>
        /// </summary>
        public Klant Klant { get; set; }

        /// <summary>
        /// Foreign key naar de Applicatie
        /// </summary>
        [ForeignKey("Applicatie")]
        [Required]
        public int ApplicatieId { get; set; }

        /// <summary>
        /// De Applicatie waarover de Ticket gaat
        /// </summary>
        public Applicatie Applicatie { get; set; }

        /// <summary>
        /// Het Onderwerp van de Ticket
        /// </summary>
        [Required]
        [StringLength(60)]
        public string Onderwerp { get; set; }

        /// <summary>
        /// De Omschrijving van de Ticket
        /// </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        public string Omschrijving { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        /// <summary>
        /// De Foreign key voor de Status
        /// </summary>
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        /// <summary>
        /// De Status van de Ticket
        /// <para>Navigatieproperty</para>
        /// </summary>
        public Status Status { get; set; }
    }
}