using ITSupport.Data;
using ITSupport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITSupport.Controllers
{
    public class TicketCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TicketCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.TicketCategories.ToListAsync());
        }

        // GET: TicketCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TicketCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketCategory ticketCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketCategory);
        }

        // GET: TicketCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {   
            if (id == null) return NotFound();

            var category = await _context.TicketCategories.FindAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        // POST: TicketCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TicketCategory ticketCategory)
        {
            if (id != ticketCategory.CategoryId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(ticketCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketCategory);
        }

        // GET: TicketCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var category = await _context.TicketCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);

            if (category == null) return NotFound();

            return View(category);
        }

        // POST: TicketCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.TicketCategories.FindAsync(id);
            if (category != null)
            {   
                _context.TicketCategories.Remove(category);
                await _context.SaveChangesAsync();
            }   
            return RedirectToAction(nameof(Index));
        }

    }
}
