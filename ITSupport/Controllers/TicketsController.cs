using ITSupport.Data;
using ITSupport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITSupport.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var role = HttpContext.Session.GetString("UserRole");
            var userId = HttpContext.Session.GetInt32("UserId");

            if (string.IsNullOrEmpty(role))
            {
            return RedirectToAction("Login", "Account");
            }

            IQueryable<Ticket> tickets = _context.Tickets
            .Include(t => t.Category)
            .Include(t => t.Priority);

            if (role == "Support")
            {
                // Support sees ONLY their tickets (created by them)
                tickets = tickets.Where(t => t.CreatedBy == userId);
            }
            else if (role == "Technician")
            {
                // Technician sees ONLY assigned tickets (we add this next)
                tickets = tickets.Where(t => t.AssignedTo == userId);
            }
            // Admin sees ALL tickets (no filter)

            return View(await tickets.ToListAsync());
        }


        // GET: Tickets/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("UserRole") != "Support")
            return RedirectToAction(nameof(Index));

            ViewBag.CategoryId = new SelectList(_context.TicketCategories, "CategoryId", "CategoryName");
            ViewBag.PriorityId = new SelectList(_context.TicketPriorities, "PriorityId", "PriorityName");
            return View();
        }


        // POST: Tickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.CreatedDate = DateTime.Now;
                ticket.Status = TicketStatus.Open;
                ticket.CreatedBy = HttpContext.Session.GetInt32("UserId") ?? 0;

                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoryId = new SelectList(_context.TicketCategories, "CategoryId", "CategoryName", ticket.CategoryId);
            ViewBag.PriorityId = new SelectList(_context.TicketPriorities, "PriorityId", "PriorityName", ticket.PriorityId);

            return View(ticket);
        }

// GET: Tickets/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null)
        return NotFound();

    var role = HttpContext.Session.GetString("UserRole");
    var userId = HttpContext.Session.GetInt32("UserId");

    var ticket = await _context.Tickets.FindAsync(id);
    if (ticket == null)
        return NotFound();

    // 🔐 SECURITY CHECKS
    if (role == "Technician" && ticket.AssignedTo != userId)
        return RedirectToAction(nameof(Index));

    if (role == "Support")
        return RedirectToAction(nameof(Index));

    // Dropdowns
    ViewBag.CategoryId = new SelectList(
        _context.TicketCategories,
        "CategoryId",
        "CategoryName",
        ticket.CategoryId
    );

    ViewBag.PriorityId = new SelectList(
        _context.TicketPriorities,
        "PriorityId",
        "PriorityName",
        ticket.PriorityId
    );

    ViewBag.StatusList = new SelectList(new[]
    {
        TicketStatus.Open,
        TicketStatus.InProgress,
        TicketStatus.Closed
    }, ticket.Status);

    return View(ticket);
}

        // POST: Tickets/Edit/5
        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, Ticket ticket)
{
    var role = HttpContext.Session.GetString("UserRole");
    var userId = HttpContext.Session.GetInt32("UserId");

    if (id != ticket.TicketId)
        return NotFound();

    if (role == "Technician" && ticket.AssignedTo != userId)
        return RedirectToAction(nameof(Index));

    if (role == "Support")
        return RedirectToAction(nameof(Index));

    if (ModelState.IsValid)
    {
        _context.Update(ticket);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    return View(ticket);
}



        // GET: Tickets/Assign/5  (Admin only)
public IActionResult Assign(int id)
{
    if (HttpContext.Session.GetString("UserRole") != "Admin")
        return RedirectToAction("Login", "Account");

    var ticket = _context.Tickets.Find(id);
    if (ticket == null) return NotFound();

    ViewBag.Technicians = new SelectList(
        _context.Users.Where(u => u.Role == "Technician"),
        "UserId",
        "FullName"
    );

    return View(ticket);
}

// POST: Tickets/Assign/5
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Assign(int id, int AssignedTo)
{
    if (HttpContext.Session.GetString("UserRole") != "Admin")
        return RedirectToAction("Login", "Account");

    var ticket = _context.Tickets.Find(id);
    if (ticket == null) return NotFound();

    ticket.AssignedTo = AssignedTo;
    ticket.Status = TicketStatus.InProgress;

    _context.SaveChanges();

    return RedirectToAction(nameof(Index));
}

        
    }
}
