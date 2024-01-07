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
    public class ClientsControllers : Controller
    {

        private readonly ApplicationDbContext _context;

        public ClientsControllers(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Clients != null ?
                View(await _context.Clients.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Clients' is null");
        }

        public async Task<IActionResult> Information(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }
        public IActionResult Create()
        {
            var model = new Clients();
            model.DateOfBirth = DateTime.Today;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("ClientID, FirstName, LastName, PhoneNumber, Email")] Clients client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();

                ViewData["Message"] = $"{client.LastName}, {client.FirstName} was successfully added";
                return View();

            }

            return View(client);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("ClientID, FirstName, LastName, PhoneNumber, Email")] Clients client)
        {
            if (id != client.ClientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(client);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{client.LastName}, {client.FirstName} was updated successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clients == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Client' is null");
            }

            Clients client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{client.LastName}, {client.FirstName} has been removed";
            }
            else
            {
                TempData["Message"] = $"This client has already been removed";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return (_context.Clients.Any(e => e.ClientID == id));
        }
    }
}