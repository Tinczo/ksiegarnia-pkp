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
    public class DokumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DokumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dokuments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dokumenty.Include(d => d.Pracownik);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dokuments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dokument = await _context.Dokumenty
                .Include(d => d.Pracownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dokument == null)
            {
                return NotFound();
            }

            return View(dokument);
        }

        // GET: Dokuments/Create
        public IActionResult Create()
        {
            ViewData["PracownikId"] = new SelectList(_context.Uzytkownik, "Id", "Id");
            return View();
        }

        // POST: Dokuments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PracownikId,NrDokumentu,DataWystawienia,Nabywca,Kwota,Podatek")] Dokument dokument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dokument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PracownikId"] = new SelectList(_context.Uzytkownik, "Id", "Id", dokument.PracownikId);
            return View(dokument);
        }

        // GET: Dokuments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dokument = await _context.Dokumenty.FindAsync(id);
            if (dokument == null)
            {
                return NotFound();
            }
            ViewData["PracownikId"] = new SelectList(_context.Uzytkownik, "Id", "Id", dokument.PracownikId);
            return View(dokument);
        }

        // POST: Dokuments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PracownikId,NrDokumentu,DataWystawienia,Nabywca,Kwota,Podatek")] Dokument dokument)
        {
            if (id != dokument.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dokument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DokumentExists(dokument.Id))
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
            ViewData["PracownikId"] = new SelectList(_context.Uzytkownik, "Id", "Id", dokument.PracownikId);
            return View(dokument);
        }

        // GET: Dokuments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dokument = await _context.Dokumenty
                .Include(d => d.Pracownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dokument == null)
            {
                return NotFound();
            }

            return View(dokument);
        }

        // POST: Dokuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dokument = await _context.Dokumenty.FindAsync(id);
            _context.Dokumenty.Remove(dokument);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DokumentExists(int id)
        {
            return _context.Dokumenty.Any(e => e.Id == id);
        }
    }
}
