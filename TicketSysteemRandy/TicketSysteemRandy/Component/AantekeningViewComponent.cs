using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSysteem.Models;

namespace TicketSysteemRandy.Components
{
    public class AantekeningViewComponent : ViewComponent
    {
        private TicketContext _context;

        public AantekeningViewComponent(TicketContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var aantekeningen = await _context.Aantekeningen
                .Include(t => t.Tekst)
                .Include(t => t.DatumTijd)
                .Where(t => t.TicketId == id)
                .ToListAsync();

            return View(aantekeningen);
        }
    }
}