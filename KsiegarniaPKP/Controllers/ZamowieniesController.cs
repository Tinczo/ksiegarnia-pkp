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
    public class ZamowieniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZamowieniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zamowienies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Zamowienia.Include(z => z.Dokument).Include(z => z.Dostawa).Include(z => z.Klient).Include(z => z.Pracownik);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Zamowienies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienia
                .Include(z => z.Dokument)
                .Include(z => z.Dostawa)
                .Include(z => z.Klient)
                .Include(z => z.Pracownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // GET: Zamowienies/Create
        public IActionResult Create()
        {
            ViewData["DokumentId"] = new SelectList(_context.Dokumenty, "Id", "Nabywca");
            ViewData["DostawaId"] = new SelectList(_context.Dostawy, "Id", "Adres");
            ViewData["KlientId"] = new SelectList(_context.Uzytkownik, "Id", "Id");
            ViewData["PracownikId"] = new SelectList(_context.Uzytkownik, "Id", "Id");
            return View();
        }

        // POST: Zamowienies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DostawaId,KlientId,PracownikId,DokumentId,NrZamowienia")] Zamowienie zamowienie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DokumentId"] = new SelectList(_context.Dokumenty, "Id", "Nabywca", zamowienie.DokumentId);
            ViewData["DostawaId"] = new SelectList(_context.Dostawy, "Id", "Adres", zamowienie.DostawaId);
            ViewData["KlientId"] = new SelectList(_context.Uzytkownik, "Id", "Id", zamowienie.KlientId);
            ViewData["PracownikId"] = new SelectList(_context.Uzytkownik, "Id", "Id", zamowienie.PracownikId);
            return View(zamowienie);
        }

        // GET: Zamowienies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienia.FindAsync(id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            ViewData["DokumentId"] = new SelectList(_context.Dokumenty, "Id", "Nabywca", zamowienie.DokumentId);
            ViewData["DostawaId"] = new SelectList(_context.Dostawy, "Id", "Adres", zamowienie.DostawaId);
            ViewData["KlientId"] = new SelectList(_context.Uzytkownik, "Id", "Id", zamowienie.KlientId);
            ViewData["PracownikId"] = new SelectList(_context.Uzytkownik, "Id", "Id", zamowienie.PracownikId);
            return View(zamowienie);
        }

        // POST: Zamowienies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DostawaId,KlientId,PracownikId,DokumentId,NrZamowienia")] Zamowienie zamowienie)
        {
            if (id != zamowienie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowienieExists(zamowienie.Id))
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
            ViewData["DokumentId"] = new SelectList(_context.Dokumenty, "Id", "Nabywca", zamowienie.DokumentId);
            ViewData["DostawaId"] = new SelectList(_context.Dostawy, "Id", "Adres", zamowienie.DostawaId);
            ViewData["KlientId"] = new SelectList(_context.Uzytkownik, "Id", "Id", zamowienie.KlientId);
            ViewData["PracownikId"] = new SelectList(_context.Uzytkownik, "Id", "Id", zamowienie.PracownikId);
            return View(zamowienie);
        }

        // GET: Zamowienies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienia
                .Include(z => z.Dokument)
                .Include(z => z.Dostawa)
                .Include(z => z.Klient)
                .Include(z => z.Pracownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // POST: Zamowienies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamowienie = await _context.Zamowienia.FindAsync(id);
            _context.Zamowienia.Remove(zamowienie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamowienieExists(int id)
        {
            return _context.Zamowienia.Any(e => e.Id == id);
        }
    }
}
