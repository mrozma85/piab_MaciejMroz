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
    public class RodzajTransportuController : Controller
    {
        private readonly ProjektIntranetContext _context;

        public RodzajTransportuController(ProjektIntranetContext context)
        {
            _context = context;
        }

        // GET: RodzajTransportu
        public async Task<IActionResult> Index()
        {
              return _context.RodzajTransportu != null ? 
                          View(await _context.RodzajTransportu.ToListAsync()) :
                          Problem("Entity set 'ProjektIntranetContext.RodzajTransportu'  is null.");
        }

        // GET: RodzajTransportu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RodzajTransportu == null)
            {
                return NotFound();
            }

            var rodzajTransportu = await _context.RodzajTransportu
                .FirstOrDefaultAsync(m => m.IdRodzajuTransportu == id);
            if (rodzajTransportu == null)
            {
                return NotFound();
            }

            return View(rodzajTransportu);
        }

        // GET: RodzajTransportu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RodzajTransportu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRodzajuTransportu,Kod,Nazwa,Cena,IdOferty,PromocjaOferty")] RodzajTransportu rodzajTransportu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rodzajTransportu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rodzajTransportu);
        }

        // GET: RodzajTransportu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RodzajTransportu == null)
            {
                return NotFound();
            }

            var rodzajTransportu = await _context.RodzajTransportu.FindAsync(id);
            if (rodzajTransportu == null)
            {
                return NotFound();
            }
            return View(rodzajTransportu);
        }

        // POST: RodzajTransportu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRodzajuTransportu,Kod,Nazwa,Cena,IdOferty,PromocjaOferty")] RodzajTransportu rodzajTransportu)
        {
            if (id != rodzajTransportu.IdRodzajuTransportu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rodzajTransportu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RodzajTransportuExists(rodzajTransportu.IdRodzajuTransportu))
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
            return View(rodzajTransportu);
        }

        // GET: RodzajTransportu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RodzajTransportu == null)
            {
                return NotFound();
            }

            var rodzajTransportu = await _context.RodzajTransportu
                .FirstOrDefaultAsync(m => m.IdRodzajuTransportu == id);
            if (rodzajTransportu == null)
            {
                return NotFound();
            }

            return View(rodzajTransportu);
        }

        // POST: RodzajTransportu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RodzajTransportu == null)
            {
                return Problem("Entity set 'ProjektIntranetContext.RodzajTransportu'  is null.");
            }
            var rodzajTransportu = await _context.RodzajTransportu.FindAsync(id);
            if (rodzajTransportu != null)
            {
                _context.RodzajTransportu.Remove(rodzajTransportu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RodzajTransportuExists(int id)
        {
          return (_context.RodzajTransportu?.Any(e => e.IdRodzajuTransportu == id)).GetValueOrDefault();
        }
    }
}
