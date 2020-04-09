using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSysteem.Models;

namespace TicketSysteem.Models
{
    public class TicketContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options">De opties, zoals database connection</param>
        public TicketContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>()
                .HasData(
                new Status() { Id = -1, Volgorde = 100, Naam = "Nieuw" },
                new Status() { Id = -2, Volgorde = 200, Naam = "In behandeling" },
                new Status() { Id = -3, Volgorde = 300, Naam = "Afgehandeld" }
                );
        }

        public DbSet<Medewerker> Medewerkers { get; set; }

        public DbSet<Klant> Klanten { get; set; }
        
        public DbSet<Applicatie> Applicaties { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Status> Statussen { get; set; }

    }
}
