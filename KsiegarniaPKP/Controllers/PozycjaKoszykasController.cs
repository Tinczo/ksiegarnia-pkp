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
    public class PozycjaKoszykasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PozycjaKoszykasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PozycjaKoszykas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PozycjaKoszyka.Include(p => p.Klient).Include(p => p.Oferta);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PozycjaKoszykas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozycjaKoszyka = await _context.PozycjaKoszyka
                .Include(p => p.Klient)
                .Include(p => p.Oferta)
                .FirstOrDefaultAsync(m => m.OfertaId == id);
            if (pozycjaKoszyka == null)
            {
                return NotFound();
            }

            return View(pozycjaKoszyka);
        }

        // GET: PozycjaKoszykas/Create
        public IActionResult Create()
        {
            ViewData["KlientId"] = new SelectList(_context.Uzytkownik, "Id", "Id");
            ViewData["OfertaId"] = new SelectList(_context.Oferty, "OfertaId", "OfertaId");
            return View();
        }

        // POST: PozycjaKoszykas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfertaId,KlientId")] PozycjaKoszyka pozycjaKoszyka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pozycjaKoszyka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlientId"] = new SelectList(_context.Uzytkownik, "Id", "Id", pozycjaKoszyka.KlientId);
            ViewData["OfertaId"] = new SelectList(_context.Oferty, "OfertaId", "OfertaId", pozycjaKoszyka.OfertaId);
            return View(pozycjaKoszyka);
        }

        // GET: PozycjaKoszykas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozycjaKoszyka = await _context.PozycjaKoszyka.FindAsync(id);
            if (pozycjaKoszyka == null)
            {
                return NotFound();
            }
            ViewData["KlientId"] = new SelectList(_context.Uzytkownik, "Id", "Id", pozycjaKoszyka.KlientId);
            ViewData["OfertaId"] = new SelectList(_context.Oferty, "OfertaId", "OfertaId", pozycjaKoszyka.OfertaId);
            return View(pozycjaKoszyka);
        }

        // POST: PozycjaKoszykas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfertaId,KlientId")] PozycjaKoszyka pozycjaKoszyka)
        {
            if (id != pozycjaKoszyka.OfertaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pozycjaKoszyka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PozycjaKoszykaExists(pozycjaKoszyka.OfertaId))
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
            ViewData["KlientId"] = new SelectList(_context.Uzytkownik, "Id", "Id", pozycjaKoszyka.KlientId);
            ViewData["OfertaId"] = new SelectList(_context.Oferty, "OfertaId", "OfertaId", pozycjaKoszyka.OfertaId);
            return View(pozycjaKoszyka);
        }

        // GET: PozycjaKoszykas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozycjaKoszyka = await _context.PozycjaKoszyka
                .Include(p => p.Klient)
                .Include(p => p.Oferta)
                .FirstOrDefaultAsync(m => m.OfertaId == id);
            if (pozycjaKoszyka == null)
            {
                return NotFound();
            }

            return View(pozycjaKoszyka);
        }

        // POST: PozycjaKoszykas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pozycjaKoszyka = await _context.PozycjaKoszyka.FindAsync(id);
            _context.PozycjaKoszyka.Remove(pozycjaKoszyka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PozycjaKoszykaExists(int id)
        {
            return _context.PozycjaKoszyka.Any(e => e.OfertaId == id);
        }
    }
}
