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
    public class PytaniaIOdpowiedzisController : Controller
    {
        private readonly ProjektIntranetContext _context;

        public PytaniaIOdpowiedzisController(ProjektIntranetContext context)
        {
            _context = context;
        }

        // GET: PytaniaIOdpowiedzis
        public async Task<IActionResult> Index()
        {
              return _context.PytaniaIOdpowiedzi != null ? 
                          View(await _context.PytaniaIOdpowiedzi.ToListAsync()) :
                          Problem("Entity set 'ProjektIntranetContext.PytaniaIOdpowiedzi'  is null.");
        }

        // GET: PytaniaIOdpowiedzis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PytaniaIOdpowiedzi == null)
            {
                return NotFound();
            }

            var pytaniaIOdpowiedzi = await _context.PytaniaIOdpowiedzi
                .FirstOrDefaultAsync(m => m.IdPytaniaIOdpowiedzi == id);
            if (pytaniaIOdpowiedzi == null)
            {
                return NotFound();
            }

            return View(pytaniaIOdpowiedzi);
        }

        // GET: PytaniaIOdpowiedzis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PytaniaIOdpowiedzis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPytaniaIOdpowiedzi,LinkPytaniaIOdpowiedzi,TytulPytaniaIOdpowiedzi,TrescPytaniaIOdpowiedzi,TytulGlownyPytaniaIOdpowiedzi,Pozycja")] PytaniaIOdpowiedzi pytaniaIOdpowiedzi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pytaniaIOdpowiedzi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pytaniaIOdpowiedzi);
        }

        // GET: PytaniaIOdpowiedzis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PytaniaIOdpowiedzi == null)
            {
                return NotFound();
            }

            var pytaniaIOdpowiedzi = await _context.PytaniaIOdpowiedzi.FindAsync(id);
            if (pytaniaIOdpowiedzi == null)
            {
                return NotFound();
            }
            return View(pytaniaIOdpowiedzi);
        }

        // POST: PytaniaIOdpowiedzis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPytaniaIOdpowiedzi,LinkPytaniaIOdpowiedzi,TytulPytaniaIOdpowiedzi,TrescPytaniaIOdpowiedzi,TytulGlownyPytaniaIOdpowiedzi,Pozycja")] PytaniaIOdpowiedzi pytaniaIOdpowiedzi)
        {
            if (id != pytaniaIOdpowiedzi.IdPytaniaIOdpowiedzi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pytaniaIOdpowiedzi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PytaniaIOdpowiedziExists(pytaniaIOdpowiedzi.IdPytaniaIOdpowiedzi))
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
            return View(pytaniaIOdpowiedzi);
        }

        // GET: PytaniaIOdpowiedzis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PytaniaIOdpowiedzi == null)
            {
                return NotFound();
            }

            var pytaniaIOdpowiedzi = await _context.PytaniaIOdpowiedzi
                .FirstOrDefaultAsync(m => m.IdPytaniaIOdpowiedzi == id);
            if (pytaniaIOdpowiedzi == null)
            {
                return NotFound();
            }

            return View(pytaniaIOdpowiedzi);
        }

        // POST: PytaniaIOdpowiedzis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PytaniaIOdpowiedzi == null)
            {
                return Problem("Entity set 'ProjektIntranetContext.PytaniaIOdpowiedzi'  is null.");
            }
            var pytaniaIOdpowiedzi = await _context.PytaniaIOdpowiedzi.FindAsync(id);
            if (pytaniaIOdpowiedzi != null)
            {
                _context.PytaniaIOdpowiedzi.Remove(pytaniaIOdpowiedzi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PytaniaIOdpowiedziExists(int id)
        {
          return (_context.PytaniaIOdpowiedzi?.Any(e => e.IdPytaniaIOdpowiedzi == id)).GetValueOrDefault();
        }
    }
}
