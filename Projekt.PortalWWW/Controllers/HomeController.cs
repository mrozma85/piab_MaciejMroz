using Microsoft.AspNetCore.Mvc;
using Projekt.PortalWWW.Models;
using Projekt.Data.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Projekt.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProjektContext _context;

        public HomeController(ProjektContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            /*ViewBag.ModelNawigacji=
                (
                from nawigacja in _context.Nawigacja
                orderby nawigacja.Pozycja
                select nawigacja
                ).ToList();

            if (id==null)
                id=_context.Nawigacja.First().IdNawigacji;
            var item = _context.Nawigacja.Find(id);
            return View(item);*/

            ViewBag.ModelStronaGlowna=
                (
                from stronaglowna in _context.StronaGlowna
                orderby stronaglowna.IdStronyGlownej
                select stronaglowna
                ).ToList();
            if (id==null)
                id=_context.StronaGlowna.First().IdStronyGlownej;

                
            var item = _context.StronaGlowna.Find(id);
            return View(item);


        }

        public IActionResult CzymSieZajmujemy(int? id)
        {
            ViewBag.ModelCzymSieZajmujemy=
                (
                from czymsiezajmujemy in _context.CzymSieZajmujemy
                orderby czymsiezajmujemy.Pozycja
                select czymsiezajmujemy
                ).ToList();
            if (id==null)
                id=_context.CzymSieZajmujemy.First().IdCzymSieZajmujemy;
            var item = _context.CzymSieZajmujemy.Find(id);
            return View(item);
        }

        public IActionResult Kontakt(int? id)
        {
            ViewBag.ModelKontakt=
                (
                from kontakt in _context.Kontakt
                orderby kontakt.Pozycja
                select kontakt
                ).ToList();

            if (id==null)
                id=_context.Kontakt.First().IdKontaktu;
            var item = _context.Kontakt.Find(id);

            return View(item);
        }

        public IActionResult Opinie()
        {
            var item = from opinie in _context.Opinie                    
                       select opinie;
            return View(item.ToList());
        }

        public IActionResult PytaniaIOdpowiedzi(int? id)
        {
            var item = from pytania in _context.PytaniaIOdpowiedzi
                       select pytania;
            return View(item.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}