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
    public class ApplicatiesController : Controller
    {
        private readonly TicketContext _context;

        public ApplicatiesController(TicketContext context)
        {
            _context = context;
        }

        // GET: Applicaties
        public async Task<IActionResult> Index()
        {
            var ticketContext = _context.Applicaties.Include(a => a.Beheerder);
            return View(await ticketContext.ToListAsync());
        }

        // GET: Applicaties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicatie = await _context.Applicaties
                .Include(a => a.Beheerder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicatie == null)
            {
                return NotFound();
            }

            return View(applicatie);
        }

        // GET: Applicaties/Create
        public IActionResult Create()
        {
            ViewData["BeheerderId"] = new SelectList(_context.Medewerkers, "Id", "Achternaam");
            return View();
        }

        // POST: Applicaties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,BeheerderId")] Applicatie applicatie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicatie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeheerderId"] = new SelectList(_context.Medewerkers, "Id", "Achternaam", applicatie.BeheerderId);
            return View(applicatie);
        }

        // GET: Applicaties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicatie = await _context.Applicaties.FindAsync(id);
            if (applicatie == null)
            {
                return NotFound();
            }
            ViewData["BeheerderId"] = new SelectList(_context.Medewerkers, "Id", "Achternaam", applicatie.BeheerderId);
            return View(applicatie);
        }

        // POST: Applicaties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,BeheerderId")] Applicatie applicatie)
        {
            if (id != applicatie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicatie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicatieExists(applicatie.Id))
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
            ViewData["BeheerderId"] = new SelectList(_context.Medewerkers, "Id", "Achternaam", applicatie.BeheerderId);
            return View(applicatie);
        }

        // GET: Applicaties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicatie = await _context.Applicaties
                .Include(a => a.Beheerder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicatie == null)
            {
                return NotFound();
            }

            return View(applicatie);
        }

        // POST: Applicaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicatie = await _context.Applicaties.FindAsync(id);
            _context.Applicaties.Remove(applicatie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicatieExists(int id)
        {
            return _context.Applicaties.Any(e => e.Id == id);
        }
    }
}
