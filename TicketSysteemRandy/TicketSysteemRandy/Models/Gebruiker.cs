using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSysteem.Models
{
    /// <summary>
    /// Gegevens die voor een gerbuiker worden opgeslaagen
    /// </summary>
    public class Gebruiker
    {
        /// <summary>
        /// Het Id van een gebruiker
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Het E-mailadres van de gebruiker
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAdres { get; set; }

        /// <summary>
        /// De Voornaam van de gebruiker (verplicht)
        /// </summary>
        [Required]
        public string Voornaam { get; set; }

        /// <summary>
        /// De (eventuele) tussenvoegsels
        /// </summary>
        public string Tussenvoegsels { get; set; }

        /// <summary>
        /// De achternaam van de gebruiker (verplicht)
        /// </summary>
        [Required]
        public string Achternaam { get; set; }
        
        [NotMapped]
        public string VolledigeNaam => $"{Voornaam} {Tussenvoegsels} {Achternaam}";

        /// <summary>
        /// Het telefoonnummer van de gebruiker
        /// </summary>
        public string Telefoonnummer { get; set; }
    }
}
