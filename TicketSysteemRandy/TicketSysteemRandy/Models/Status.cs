using System.ComponentModel.DataAnnotations;

namespace TicketSysteem.Models
{
    /// <summary>
    /// De Status die een Ticket kan hebben
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Het Id van de Status
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// De volgorde van de Status. De laagste wordt toegekend aan nieuwe Tickets
        /// </summary>
        public int Volgorde { get; set; }


        /// <summary>
        /// De naam van de status.
        /// <para>Standaard: 'Nieuw', 'In behandeling' of 'Afgehandeld'</para>
        /// </summary>
        [StringLength(20)]
        [Required]
        public string Naam { get; set; }
    }
}