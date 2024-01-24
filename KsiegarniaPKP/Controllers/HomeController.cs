using KsiegarniaPKP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KsiegarniaPKP.Controllers
{
    // TODO: [X] sprawdzić czemu nie działa komunikat, kiedy nie ma już więcej książek
    // TODO: [X] dodac obliczenie sumy w koszyku
    // TODO: [X] dodac cene do ksiązki w koszyku i sumarycznie (cena razy ilość) - po prawej stronie
    // TODO: [X] wyrównać, żeby nazwy były pośrodku w kolumnach
    // TODO: [ ] dodać grafiki
    // TODO: [ ] dodac wyszukiwarke z filtrami (zbierac z wszystkich dostępnych ofert informacje takie jak gatunki, Autora, roadio button rosnąco czy malejąco,
    // TODO: [ ] szukanie po nazwie ksiazki, generalnie wszystko co tam jest, sprawdź dodawanie przycisków 
    // TODO: [ ] zamienic logowanie na stary sposob, usunac id i zobaczyc czy bez tego dziala
    // TODO: [ ] dodać do rejestracji imię i nazwisko, żeby działało i sprawdzić, czy rejestracja działa
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
