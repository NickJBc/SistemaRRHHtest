using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaRRHH.Data;
using SistemaRRHH.Models;

namespace SistemaRRHH.Controllers
{
    public class FamiliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FamiliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Families
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Family.Include(f => f.Worker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Families/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Family == null)
            {
                return NotFound();
            }

            var family = await _context.Family
                .Include(f => f.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (family == null)
            {
                return NotFound();
            }

            return View(family);
        }

        // GET: Families/Create
        public IActionResult Create()
        {
            ViewData["WorkerId"] = new SelectList(_context.Worker, "id", "id");
            return View();
        }

        // POST: Families/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,BirthDay,Relation,PhoneNumber,WorkerId")] Family family)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _context.Add(family);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkerId"] = new SelectList(_context.Worker, "id", "id", family.WorkerId);
            return View(family);
        }

        // GET: Families/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Family == null)
            {
                return NotFound();
            }

            var family = await _context.Family.FindAsync(id);
            if (family == null)
            {
                return NotFound();
            }
            ViewData["WorkerId"] = new SelectList(_context.Worker, "id", "id", family.WorkerId);
            return View(family);
        }

        // POST: Families/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,BirthDay,Relation,PhoneNumber,WorkerId")] Family family)
        {
            if (id != family.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(family);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamilyExists(family.Id))
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
            ViewData["WorkerId"] = new SelectList(_context.Worker, "id", "id", family.WorkerId);
            return View(family);
        }

        // GET: Families/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Family == null)
            {
                return NotFound();
            }

            var family = await _context.Family
                .Include(f => f.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (family == null)
            {
                return NotFound();
            }

            return View(family);
        }

        // POST: Families/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Family == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Family'  is null.");
            }
            var family = await _context.Family.FindAsync(id);
            if (family != null)
            {
                _context.Family.Remove(family);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamilyExists(int id)
        {
          return (_context.Family?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
