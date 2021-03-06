﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketSysteem.Models;

namespace TicketSysteem.Controllers
{
    public class MedewerkersController : Controller
    {
        private readonly TicketContext _context;

        public MedewerkersController(TicketContext context)
        {
            _context = context;
        }

        // GET: Medewerkers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medewerkers.ToListAsync());
        }

        // GET: Medewerkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medewerker = await _context.Medewerkers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medewerker == null)
            {
                return NotFound();
            }

            return View(medewerker);
        }

        // GET: Medewerkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medewerkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmailAdres,Voornaam,Tussenvoegsels,Achternaam,Telefoonnummer")] Medewerker medewerker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medewerker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medewerker);
        }

        // GET: Medewerkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medewerker = await _context.Medewerkers.FindAsync(id);
            if (medewerker == null)
            {
                return NotFound();
            }
            return View(medewerker);
        }

        // POST: Medewerkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmailAdres,Voornaam,Tussenvoegsels,Achternaam,Telefoonnummer")] Medewerker medewerker)
        {
            if (id != medewerker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medewerker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedewerkerExists(medewerker.Id))
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
            return View(medewerker);
        }

        // GET: Medewerkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medewerker = await _context.Medewerkers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medewerker == null)
            {
                return NotFound();
            }

            return View(medewerker);
        }

        // POST: Medewerkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medewerker = await _context.Medewerkers.FindAsync(id);
            _context.Medewerkers.Remove(medewerker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedewerkerExists(int id)
        {
            return _context.Medewerkers.Any(e => e.Id == id);
        }
    }
}
