#nullable disable
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
    public class OpinieController : Controller
    {
        private readonly ProjektIntranetContext _context;

        public OpinieController(ProjektIntranetContext context)
        {
            _context = context;
        }

        // GET: Opinie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Opinie.ToListAsync());
        }

        // GET: Opinie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinie = await _context.Opinie
                .FirstOrDefaultAsync(m => m.IdOpini == id);
            if (opinie == null)
            {
                return NotFound();
            }

            return View(opinie);
        }

        // GET: Opinie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Opinie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOpini,LinkOpini,Naglowek1Opini,Naglowek2Opini,ImieINazwiskoDodajacego,TrescOpini,Pozycja")] Opinie opinie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opinie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opinie);
        }

        // GET: Opinie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinie = await _context.Opinie.FindAsync(id);
            if (opinie == null)
            {
                return NotFound();
            }
            return View(opinie);
        }

        // POST: Opinie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOpini,LinkOpini,Naglowek1Opini,Naglowek2Opini,ImieINazwiskoDodajacego,TrescOpini,Pozycja")] Opinie opinie)
        {
            if (id != opinie.IdOpini)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opinie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpinieExists(opinie.IdOpini))
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
            return View(opinie);
        }

        // GET: Opinie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinie = await _context.Opinie
                .FirstOrDefaultAsync(m => m.IdOpini == id);
            if (opinie == null)
            {
                return NotFound();
            }

            return View(opinie);
        }

        // POST: Opinie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opinie = await _context.Opinie.FindAsync(id);
            _context.Opinie.Remove(opinie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpinieExists(int id)
        {
            return _context.Opinie.Any(e => e.IdOpini == id);
        }
    }
}
