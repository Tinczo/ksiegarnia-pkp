using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KsiegarniaPKP.Models;

namespace KsiegarniaPKP.Controllers
{
    public class DostawasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DostawasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dostawas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dostawy.Include(d => d.Kurier).Include(d => d.Pracownik);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dostawas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dostawa = await _context.Dostawy
                .Include(d => d.Kurier)
                .Include(d => d.Pracownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dostawa == null)
            {
                return NotFound();
            }

            return View(dostawa);
        }

        // GET: Dostawas/Create
        public IActionResult Create()
        {
            ViewData["KurierId"] = new SelectList(_context.Uzytkownik, "Id", "Id");
            ViewData["PracownikId"] = new SelectList(_context.Uzytkownik, "Id", "Id");
            return View();
        }

        // POST: Dostawas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PracownikId,KurierId,Adres,Status,CzyOplacone")] Dostawa dostawa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dostawa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KurierId"] = new SelectList(_context.Uzytkownik, "Id", "Id", dostawa.KurierId);
            ViewData["PracownikId"] = new SelectList(_context.Uzytkownik, "Id", "Id", dostawa.PracownikId);
            return View(dostawa);
        }

        // GET: Dostawas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dostawa = await _context.Dostawy.FindAsync(id);
            if (dostawa == null)
            {
                return NotFound();
            }
            ViewData["KurierId"] = new SelectList(_context.Uzytkownik, "Id", "Id", dostawa.KurierId);
            ViewData["PracownikId"] = new SelectList(_context.Uzytkownik, "Id", "Id", dostawa.PracownikId);
            return View(dostawa);
        }

        // POST: Dostawas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PracownikId,KurierId,Adres,Status,CzyOplacone")] Dostawa dostawa)
        {
            if (id != dostawa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dostawa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DostawaExists(dostawa.Id))
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
            ViewData["KurierId"] = new SelectList(_context.Uzytkownik, "Id", "Id", dostawa.KurierId);
            ViewData["PracownikId"] = new SelectList(_context.Uzytkownik, "Id", "Id", dostawa.PracownikId);
            return View(dostawa);
        }

        // GET: Dostawas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dostawa = await _context.Dostawy
                .Include(d => d.Kurier)
                .Include(d => d.Pracownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dostawa == null)
            {
                return NotFound();
            }

            return View(dostawa);
        }

        // POST: Dostawas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dostawa = await _context.Dostawy.FindAsync(id);
            _context.Dostawy.Remove(dostawa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DostawaExists(int id)
        {
            return _context.Dostawy.Any(e => e.Id == id);
        }
    }
}
