using System.Collections.Generic;

namespace TicketSysteem.Models
{
    /// <summary>
    /// Een Medewerker is een Gebruiker.
    /// Een Medewerker beheert nul of meer Applicaties
    /// </summary>
    public class Medewerker : Gebruiker
    {
        /// <summary>
        ///  Een Medewerker beheert nul of meer Applicaties.
        ///  <para>Navigatie Property</para>
        /// </summary>
        public ICollection<Applicatie> Applicaties { get; set; }
    }
}
