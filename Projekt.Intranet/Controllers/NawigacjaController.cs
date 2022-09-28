#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data;
using Projekt.Data.Data.CMS;

namespace Projekt.Intranet.Controllers
{
    public class NawigacjaController : Controller
    {
        private readonly ProjektContext _context;

        public NawigacjaController(ProjektContext context)
        {
            _context = context;
        }

        // GET: Nawigacja
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nawigacja.ToListAsync());
        }

        // GET: Nawigacja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nawigacja = await _context.Nawigacja
                .FirstOrDefaultAsync(m => m.IdNawigacji == id);
            if (nawigacja == null)
            {
                return NotFound();
            }

            return View(nawigacja);
        }

        // GET: Nawigacja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nawigacja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNawigacji,LinkNawigacji,TytulNawigacji,TrescNawigacji,Pozycja")] Nawigacja nawigacja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nawigacja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nawigacja);
        }

        // GET: Nawigacja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nawigacja = await _context.Nawigacja.FindAsync(id);
            if (nawigacja == null)
            {
                return NotFound();
            }
            return View(nawigacja);
        }

        // POST: Nawigacja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNawigacji,LinkNawigacji,TytulNawigacji,TrescNawigacji,Pozycja")] Nawigacja nawigacja)
        {
            if (id != nawigacja.IdNawigacji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nawigacja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NawigacjaExists(nawigacja.IdNawigacji))
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
            return View(nawigacja);
        }

        // GET: Nawigacja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nawigacja = await _context.Nawigacja
                .FirstOrDefaultAsync(m => m.IdNawigacji == id);
            if (nawigacja == null)
            {
                return NotFound();
            }

            return View(nawigacja);
        }

        // POST: Nawigacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nawigacja = await _context.Nawigacja.FindAsync(id);
            _context.Nawigacja.Remove(nawigacja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NawigacjaExists(int id)
        {
            return _context.Nawigacja.Any(e => e.IdNawigacji == id);
        }
    }
}
