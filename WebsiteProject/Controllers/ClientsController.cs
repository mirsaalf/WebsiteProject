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
    public class ClientsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return _context.Clients != null ?
                View(await _context.Clients.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Clients' is null");
        }

        // GET: Client Information
        public async Task<IActionResult> Information(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var clients = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (clients == null)
            {
                return NotFound();
            }
            return View(clients);
        }

        //GET: Clients/Create
        public IActionResult Create()
        {
            var model = new Clients();
            model.DateOfBirth = DateTime.Today;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public async Task<IActionResult> Create([Bind("ClientID, FirstName, LastName, PhoneNumber, Email")] Clients clients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clients);
                await _context.SaveChangesAsync();

                ViewData["Message"] = $"{clients.LastName}, {clients.FirstName} was successfully added";
                return View();

            }

            return View(clients);
        }

        //GET: Clients/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var clients = await _context.Clients.FindAsync(id);
            if (clients == null)
            {
                return NotFound();
            }

            return View(clients);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        // POST: Clients/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public async Task<IActionResult> Edit(int id, [Bind("ClientID, FirstName, LastName, PhoneNumber, Email")] Clients clients)
        {
            if (id != clients.ClientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(clients);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{clients.LastName}, {clients.FirstName} was updated successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(clients);
        }

        // GET: Clients/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var clients = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (clients == null)
            {
                return NotFound();
            }

            return View(clients);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]


        // POST: Clients/Delete
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clients == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Clients' is null");
            }

            Clients clients = await _context.Clients.FindAsync(id);

            if (clients != null)
            {
                _context.Clients.Remove(clients);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{clients.LastName}, {clients.FirstName} has been removed";
            }
            else
            {
                TempData["Message"] = "This client has already been removed";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return (_context.Clients.Any(e => e.ClientID == id));
        }
    }
}