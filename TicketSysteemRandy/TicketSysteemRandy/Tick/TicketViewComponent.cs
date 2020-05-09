using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSysteem.Models;

namespace TicketSysteem.ViewComponents
{
    public class TicketViewComponent : ViewComponent
    {
        private TicketContext _context;
        public TicketViewComponent(TicketContext context)
        {
            _context = context;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Tickets.ToListAsync());
        }

    }
}