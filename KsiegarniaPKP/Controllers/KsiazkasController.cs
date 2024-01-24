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
    public class KsiazkasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KsiazkasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ksiazkas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ksiazki.ToListAsync());
        }

        // GET: Ksiazkas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ksiazka == null)
            {
                return NotFound();
            }

            return View(ksiazka);
        }

        // GET: Ksiazkas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ksiazkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Autor,Tytul,Gatunek,Opis,Cena")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ksiazka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ksiazka);
        }

        // GET: Ksiazkas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazki.FindAsync(id);
            if (ksiazka == null)
            {
                return NotFound();
            }
            return View(ksiazka);
        }

        // POST: Ksiazkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Autor,Tytul,Gatunek,Opis,Cena")] Ksiazka ksiazka)
        {
            if (id != ksiazka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ksiazka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KsiazkaExists(ksiazka.Id))
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
            return View(ksiazka);
        }

        // GET: Ksiazkas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ksiazka == null)
            {
                return NotFound();
            }

            return View(ksiazka);
        }

        // POST: Ksiazkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ksiazka = await _context.Ksiazki.FindAsync(id);
            _context.Ksiazki.Remove(ksiazka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KsiazkaExists(int id)
        {
            return _context.Ksiazki.Any(e => e.Id == id);
        }

    }
}
