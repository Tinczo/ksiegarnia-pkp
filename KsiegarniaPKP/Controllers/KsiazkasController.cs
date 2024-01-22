using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KsiegarniaPKP.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace KsiegarniaPKP.Controllers
{
    public class KsiazkasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<KsiazkasController> _logger;

        public KsiazkasController(ApplicationDbContext context, ILogger<KsiazkasController> logger)
        {
            _context = context;
            _logger = logger;
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
        public async Task<IActionResult> Create([Bind("Id,Autor,Tytul,RokWydania,Opis,Cena,Obrazek")] KsiazkaCreateView ksiazkaView)
        {
            if (ModelState.IsValid)
            {
                var ksiazka = new Ksiazka
                {
                    Id = ksiazkaView.Id,
                    Autor = ksiazkaView.Autor,
                    Tytul = ksiazkaView.Tytul,
                    RokWydania = ksiazkaView.RokWydania,
                    Opis = ksiazkaView.Opis,
                    Cena = ksiazkaView.Cena,
                };

                if (ksiazkaView.Obrazek != null && ksiazkaView.Obrazek.Length > 0)
                {
                    var fileName = Path.GetFileName(ksiazkaView.Obrazek.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/book-images", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await ksiazkaView.Obrazek.CopyToAsync(fileSteam);
                    }
                    ksiazka.ObrazekUrl = "/book-images/" + fileName; // Zapisz ścieżkę obrazka
                }

                _context.Add(ksiazka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ksiazkaView);
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

            var ksiazkaView = new KsiazkaEditView
            {
                Id = ksiazka.Id,
                Autor = ksiazka.Autor,
                Tytul = ksiazka.Tytul,
                RokWydania = ksiazka.RokWydania,
                Opis = ksiazka.Opis,
                Cena = ksiazka.Cena,
            };

            return View(ksiazkaView);
        }

        // POST: Ksiazkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Autor,Tytul,RokWydania,Opis,Cena,Obrazek")] KsiazkaEditView ksiazkaView)
        {
            if (id != ksiazkaView.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ksiazka = await _context.Ksiazki.FirstOrDefaultAsync(k => k.Id == ksiazkaView.Id);
                    if (ksiazka == null)
                    {
                        return NotFound();
                    }

                    ksiazka.Autor = ksiazkaView.Autor;
                    ksiazka.Tytul = ksiazkaView.Tytul;
                    ksiazka.RokWydania = ksiazkaView.RokWydania;
                    ksiazka.Opis = ksiazkaView.Opis;
                    ksiazka.Cena = ksiazkaView.Cena;

                    if (ksiazkaView.Obrazek != null && ksiazkaView.Obrazek.Length > 0)
                    {
                        var fileName = Path.GetFileName(ksiazkaView.Obrazek.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/book-images", fileName);
                        using (var fileSteam = new FileStream(filePath, FileMode.Create))
                        {
                            await ksiazkaView.Obrazek.CopyToAsync(fileSteam);
                        }
                        ksiazka.ObrazekUrl = "/book-images/" + fileName;
                    }

                    _context.Update(ksiazka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KsiazkaExists(ksiazkaView.Id))
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
            return View(ksiazkaView);
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
