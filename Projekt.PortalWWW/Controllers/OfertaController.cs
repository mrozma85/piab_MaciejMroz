using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data;

namespace Projekt.PortalWWW.Controllers
{
    public class OfertaController : Controller
    {
        private readonly ProjektContext _context;
        public OfertaController(ProjektContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.ModelRodzaje = await _context.Oferta.ToListAsync();
            if(id==null)
            {
                var pierwszy = await _context.Oferta.FirstAsync();
                id = pierwszy.IdOferty;
            }
            return View(await _context.RodzajTransportu.Where(t => t.IdOferty==id).ToListAsync());
        }

    }
}
