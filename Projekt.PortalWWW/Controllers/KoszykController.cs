using Microsoft.AspNetCore.Mvc;
using Projekt.Data.Data;
using Projekt.PortalWWW.Models.BuisnessLogic;
using Projekt.PortalWWW.Models.Oferta;

namespace Projekt.PortalWWW.Controllers
{
    public class KoszykController : Controller
    {
        private readonly ProjektContext _context;
        public KoszykController(ProjektContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            KoszykB koszykB = new KoszykB(_context, this.HttpContext);
            DaneDoOferty daneDoKoszyka = new DaneDoOferty()
            {
                ElementyKoszyka = await koszykB.GetElementyKoszykaKlienta(),
                Razem = await koszykB.GetRazem()
            };
            return View(daneDoKoszyka);
        }
        //funkcja obluguje do dodawania towaru do koszyka
        public async Task<IActionResult> DodajDoKoszyka(int id)
        {
            KoszykB koszykB = new KoszykB(_context, this.HttpContext);
            koszykB.DodajDoKoszyka(await _context.RodzajTransportu.FindAsync(id));
            return RedirectToAction("Index"); // po daodaniu do koszyka przechodzimy do index czyli glowny widok koszyka
        }
    }
}