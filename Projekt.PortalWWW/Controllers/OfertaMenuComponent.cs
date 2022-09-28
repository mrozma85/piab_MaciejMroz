using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data;

namespace Projekt.PortalWWW.Controllers
{
    public class OfertaMenuComponent : ViewComponent
    {
        private readonly ProjektContext _context;
        public OfertaMenuComponent(ProjektContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("OfertaMenuComponent", await _context.Oferta.ToListAsync());
        }
    }
}
