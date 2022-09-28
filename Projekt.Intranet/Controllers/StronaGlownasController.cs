using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data.CMS;
using Projekt.Intranet.Data;

namespace Projekt.Intranet.Controllers
{
    public class StronaGlownasController : Controller
    {
        private readonly ProjektIntranetContext _context;

        public StronaGlownasController(ProjektIntranetContext context)
        {
            _context = context;
        }

        // GET: StronaGlownas
        public async Task<IActionResult> Index()
        {
              return _context.StronaGlowna != null ? 
                          View(await _context.StronaGlowna.ToListAsync()) :
                          Problem("Entity set 'ProjektIntranetContext.StronaGlowna'  is null.");
        }

        // GET: StronaGlownas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StronaGlowna == null)
            {
                return NotFound();
            }

            var stronaGlowna = await _context.StronaGlowna
                .FirstOrDefaultAsync(m => m.IdStronyGlownej == id);
            if (stronaGlowna == null)
            {
                return NotFound();
            }

            return View(stronaGlowna);
        }

        // GET: StronaGlownas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StronaGlownas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStronyGlownej,Tytul1StronyGlownej,Tytul2StronyGlownej")] StronaGlowna stronaGlowna)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stronaGlowna);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stronaGlowna);
        }

        // GET: StronaGlownas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StronaGlowna == null)
            {
                return NotFound();
            }

            var stronaGlowna = await _context.StronaGlowna.FindAsync(id);
            if (stronaGlowna == null)
            {
                return NotFound();
            }
            return View(stronaGlowna);
        }

        // POST: StronaGlownas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStronyGlownej,Tytul1StronyGlownej,Tytul2StronyGlownej")] StronaGlowna stronaGlowna)
        {
            if (id != stronaGlowna.IdStronyGlownej)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stronaGlowna);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StronaGlownaExists(stronaGlowna.IdStronyGlownej))
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
            return View(stronaGlowna);
        }

        // GET: StronaGlownas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StronaGlowna == null)
            {
                return NotFound();
            }

            var stronaGlowna = await _context.StronaGlowna
                .FirstOrDefaultAsync(m => m.IdStronyGlownej == id);
            if (stronaGlowna == null)
            {
                return NotFound();
            }

            return View(stronaGlowna);
        }

        // POST: StronaGlownas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StronaGlowna == null)
            {
                return Problem("Entity set 'ProjektIntranetContext.StronaGlowna'  is null.");
            }
            var stronaGlowna = await _context.StronaGlowna.FindAsync(id);
            if (stronaGlowna != null)
            {
                _context.StronaGlowna.Remove(stronaGlowna);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StronaGlownaExists(int id)
        {
          return (_context.StronaGlowna?.Any(e => e.IdStronyGlownej == id)).GetValueOrDefault();
        }
    }
}
