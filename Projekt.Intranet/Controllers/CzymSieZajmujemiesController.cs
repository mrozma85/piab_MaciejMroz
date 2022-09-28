#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data.CMS;
using Projekt.Intranet.Data;

namespace Projekt.Intranet.Controllers
{
    public class CzymSieZajmujemiesController : Controller
    {
        private readonly ProjektIntranetContext _context;

        public CzymSieZajmujemiesController(ProjektIntranetContext context)
        {
            _context = context;
        }

        // GET: CzymSieZajmujemies
        public async Task<IActionResult> Index()
        {
            return View(await _context.CzymSieZajmujemy.ToListAsync());
        }

        // GET: CzymSieZajmujemies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var czymSieZajmujemy = await _context.CzymSieZajmujemy
                .FirstOrDefaultAsync(m => m.IdCzymSieZajmujemy == id);
            if (czymSieZajmujemy == null)
            {
                return NotFound();
            }

            return View(czymSieZajmujemy);
        }

        // GET: CzymSieZajmujemies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CzymSieZajmujemies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCzymSieZajmujemy,LinkCzymSieZajmujemy,TytulCzymSieZajmujemy,Tresc1CzymSieZajmujemy,Tresc2CzymSieZajmujemy,Pozycja")] CzymSieZajmujemy czymSieZajmujemy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(czymSieZajmujemy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(czymSieZajmujemy);
        }

        // GET: CzymSieZajmujemies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var czymSieZajmujemy = await _context.CzymSieZajmujemy.FindAsync(id);
            if (czymSieZajmujemy == null)
            {
                return NotFound();
            }
            return View(czymSieZajmujemy);
        }

        // POST: CzymSieZajmujemies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCzymSieZajmujemy,LinkCzymSieZajmujemy,TytulCzymSieZajmujemy,Tresc1CzymSieZajmujemy,Tresc2CzymSieZajmujemy,Pozycja")] CzymSieZajmujemy czymSieZajmujemy)
        {
            if (id != czymSieZajmujemy.IdCzymSieZajmujemy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(czymSieZajmujemy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CzymSieZajmujemyExists(czymSieZajmujemy.IdCzymSieZajmujemy))
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
            return View(czymSieZajmujemy);
        }

        // GET: CzymSieZajmujemies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var czymSieZajmujemy = await _context.CzymSieZajmujemy
                .FirstOrDefaultAsync(m => m.IdCzymSieZajmujemy == id);
            if (czymSieZajmujemy == null)
            {
                return NotFound();
            }

            return View(czymSieZajmujemy);
        }

        // POST: CzymSieZajmujemies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var czymSieZajmujemy = await _context.CzymSieZajmujemy.FindAsync(id);
            _context.CzymSieZajmujemy.Remove(czymSieZajmujemy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CzymSieZajmujemyExists(int id)
        {
            return _context.CzymSieZajmujemy.Any(e => e.IdCzymSieZajmujemy == id);
        }
    }
}
