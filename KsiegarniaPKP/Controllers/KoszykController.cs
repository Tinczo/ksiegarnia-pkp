using KsiegarniaPKP.Models;
using KsiegarniaPKP.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace KsiegarniaPKP.Controllers
{
    [Authorize(Roles = "Uzytkownik")]
    public class KoszykController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnviroment;
        private UserManager<Uzytkownik> _userManager;
        public KoszykController(ApplicationDbContext context, IHostingEnvironment hostingEnviroment, UserManager<Uzytkownik> userManager)
        {
            _context = context;
            _hostingEnviroment = hostingEnviroment;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);

            var pozycjeKoszyka = await _context.PozycjaKoszyka
                .Where(pk => pk.KlientId == userId)
                .Include(pk => pk.Oferta)
                .ThenInclude(o => o.Ksiazka)
                .ToListAsync();

            var koszyk = pozycjeKoszyka
                .GroupBy(pk => pk.Oferta.Ksiazka)
                .Select(group => new PozycjaKoszykaViewModel
                {
                    Ksiazka = group.Key,
                    Ilosc = group.Count()
                }).ToList();

            return View(koszyk);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IncrementCartItem(int ksiazkaId)
        {
            string userId = _userManager.GetUserId(User);

            var oferta = _context.Oferty
                                 .FirstOrDefault(o => o.Dostepnosc && o.KsiazkaId == ksiazkaId);

            if (oferta == null)
            {
                ViewBag.brakOfert = true;
                return RedirectToAction("Index");
            }

            oferta.Dostepnosc = false;

            var pozycjaKoszyka = new PozycjaKoszyka
            {
                KlientId = userId,
                OfertaId = oferta.OfertaId
            };
            _context.PozycjaKoszyka.Add(pozycjaKoszyka);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Błąd podczas zapisu do bazy danych");
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DecrementCartItem(int ksiazkaId)
        {
            string userId = _userManager.GetUserId(User);

            var pozycjaKoszyka = _context.PozycjaKoszyka
                                         .Include(pk => pk.Oferta)
                                         .FirstOrDefault(pk => pk.KlientId == userId && pk.Oferta.KsiazkaId == ksiazkaId);

            if (pozycjaKoszyka == null)
            {
                return NotFound();
            }

            _context.PozycjaKoszyka.Remove(pozycjaKoszyka);

            var oferta = _context.Oferty
                                 .FirstOrDefault(o => o.OfertaId == pozycjaKoszyka.OfertaId);

            if (oferta != null)
            {
                oferta.Dostepnosc = true;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Błąd podczas zapisu do bazy danych");
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveCartItem(int ksiazkaId)
        {
            var pozycjeKoszyka = _context.PozycjaKoszyka
                                         .Include(pk => pk.Oferta)
                                         .Where(pk => pk.Oferta.KsiazkaId == ksiazkaId)
                                         .ToList();

            if (!pozycjeKoszyka.Any())
            {
                return NotFound();
            }

            _context.PozycjaKoszyka.RemoveRange(pozycjeKoszyka);

            var ofertaIds = pozycjeKoszyka.Select(pk => pk.OfertaId).Distinct();
            var oferty = _context.Oferty
                                 .Where(o => ofertaIds.Contains(o.OfertaId))
                                 .ToList();

            foreach (var oferta in oferty)
            {
                oferta.Dostepnosc = true;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Błąd podczas zapisu do bazy danych");
            }

            return RedirectToAction("Index");
        }


    }
}
