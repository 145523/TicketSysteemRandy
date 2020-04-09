using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketSysteem.Models;

namespace TicketSysteem.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketContext _context;

        public TicketsController(TicketContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var ticketContext = _context.Tickets.Include(t => t.Applicatie).Include(t => t.Klant).Include(t => t.Status);
            return View(await ticketContext.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Applicatie)
                .Include(t => t.Klant)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["ApplicatieId"] = new SelectList(_context.Applicaties, "Id", "Naam");
            ViewData["KlantId"] = new SelectList(_context.Klanten, "Id", "Achternaam");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KlantId,ApplicatieId,Onderwerp,Omschrijving")] Ticket ticket)
        {
            Status status = _context.Statussen.OrderBy(s => s.Volgorde).FirstOrDefault();
            ticket.StatusId = status.Id;

            ticket.Datum = DateTime.Today;

            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicatieId"] = new SelectList(_context.Applicaties, "Id", "Naam", ticket.ApplicatieId);
            ViewData["KlantId"] = new SelectList(_context.Klanten, "Id", "Achternaam", ticket.KlantId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["ApplicatieId"] = new SelectList(_context.Applicaties, "Id", "Naam", ticket.ApplicatieId);
            ViewData["KlantId"] = new SelectList(_context.Klanten, "Id", "Achternaam", ticket.KlantId);
            ViewData["StatusId"] = new SelectList(_context.Statussen, "Id", "Naam", ticket.StatusId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KlantId,ApplicatieId,Onderwerp,Omschrijving,Datum,StatusId")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicatieId"] = new SelectList(_context.Applicaties, "Id", "Naam", ticket.ApplicatieId);
            ViewData["KlantId"] = new SelectList(_context.Klanten, "Id", "Achternaam", ticket.KlantId);
            ViewData["StatusId"] = new SelectList(_context.Statussen, "Id", "Naam", ticket.StatusId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Applicatie)
                .Include(t => t.Klant)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
