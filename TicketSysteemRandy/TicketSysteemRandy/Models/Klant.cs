using System.Collections.Generic;

namespace TicketSysteem.Models
{
    /// <summary>
    /// Een Klant is een Gebruiker.
    /// Een Klant kan nul of meer Tickets hebben ingelegd.
    /// </summary>
    public class Klant : Gebruiker
    {
        /// <summary>
        /// Een Klant kan nul of meer Tickets hebben ingelegd.
        /// <para>Navigatieproperty</para>
        /// </summary>
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
