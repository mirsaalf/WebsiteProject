using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsiteProject.Data;
using WebsiteProject.Models;

namespace WebsiteProject.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Services != null ?
                View(await _context.Services.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Services' is null");
        }

        public async Task<IActionResult> Information(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var services = await _context.Services
                .FirstOrDefaultAsync(m => m.ServiceID == id);
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("ServiceID,ServiceName,ServicePrice,ServiceDescription")] Services services)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(services);
                await _context.SaveChangesAsync();

                ViewData["Message"] = $"{services.ServiceName} has been added successfully.";
                return View();
            }

            return View(services);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var services = await _context.Services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("ServiceID,ServiceName,ServicePrice,ServiceDescription")] Services services)
        {
            if (id != services.ServiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(services);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{services.ServiceName} was changed successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(services);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var services = await _context.Services
                .FirstOrDefaultAsync(m => m.ServiceID == id);
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Services == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Services' is null");

            }
            var services = await _context.Services.FindAsync(id);
            if(services == null)
            {
                _context.Services.Remove(services);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{services.ServiceName} was removed successfully";
            }
            else
            {
                TempData["Message"] = $"{services.ServiceName} has already been removed";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
            return (_context.Services?.Any(e => e.ServiceID == id)).GetValueOrDefault();
        }
    }
}
