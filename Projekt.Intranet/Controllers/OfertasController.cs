using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data.Oferta;
using Projekt.Intranet.Data;

namespace Projekt.Intranet.Controllers
{
    public class OfertasController : Controller
    {
        private readonly ProjektIntranetContext _context;

        public OfertasController(ProjektIntranetContext context)
        {
            _context = context;
        }

        // GET: Ofertas
        public async Task<IActionResult> Index()
        {
              return _context.Oferta != null ? 
                          View(await _context.Oferta.ToListAsync()) :
                          Problem("Entity set 'ProjektIntranetContext.Oferta'  is null.");
        }

        // GET: Ofertas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Oferta == null)
            {
                return NotFound();
            }

            var oferta = await _context.Oferta
                .FirstOrDefaultAsync(m => m.IdOferty == id);
            if (oferta == null)
            {
                return NotFound();
            }

            return View(oferta);
        }

        // GET: Ofertas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ofertas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOferty,Nazwa,Opis")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oferta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oferta);
        }

        // GET: Ofertas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Oferta == null)
            {
                return NotFound();
            }

            var oferta = await _context.Oferta.FindAsync(id);
            if (oferta == null)
            {
                return NotFound();
            }
            return View(oferta);
        }

        // POST: Ofertas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOferty,Nazwa,Opis")] Oferta oferta)
        {
            if (id != oferta.IdOferty)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oferta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfertaExists(oferta.IdOferty))
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
            return View(oferta);
        }

        // GET: Ofertas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Oferta == null)
            {
                return NotFound();
            }

            var oferta = await _context.Oferta
                .FirstOrDefaultAsync(m => m.IdOferty == id);
            if (oferta == null)
            {
                return NotFound();
            }

            return View(oferta);
        }

        // POST: Ofertas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Oferta == null)
            {
                return Problem("Entity set 'ProjektIntranetContext.Oferta'  is null.");
            }
            var oferta = await _context.Oferta.FindAsync(id);
            if (oferta != null)
            {
                _context.Oferta.Remove(oferta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfertaExists(int id)
        {
          return (_context.Oferta?.Any(e => e.IdOferty == id)).GetValueOrDefault();
        }
    }
}
