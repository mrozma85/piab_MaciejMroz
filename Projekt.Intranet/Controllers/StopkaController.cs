﻿using System;
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
    public class StopkaController : Controller
    {
        private readonly ProjektIntranetContext _context;

        public StopkaController(ProjektIntranetContext context)
        {
            _context = context;
        }

        // GET: Stopka
        public async Task<IActionResult> Index()
        {
              return _context.Stopka != null ? 
                          View(await _context.Stopka.ToListAsync()) :
                          Problem("Entity set 'ProjektIntranetContext.Stopka'  is null.");
        }

        // GET: Stopka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stopka == null)
            {
                return NotFound();
            }

            var stopka = await _context.Stopka
                .FirstOrDefaultAsync(m => m.IdStopki == id);
            if (stopka == null)
            {
                return NotFound();
            }

            return View(stopka);
        }

        // GET: Stopka/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stopka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStopki,NazwaStopki")] Stopka stopka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stopka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stopka);
        }

        // GET: Stopka/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stopka == null)
            {
                return NotFound();
            }

            var stopka = await _context.Stopka.FindAsync(id);
            if (stopka == null)
            {
                return NotFound();
            }
            return View(stopka);
        }

        // POST: Stopka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStopki,NazwaStopki")] Stopka stopka)
        {
            if (id != stopka.IdStopki)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stopka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StopkaExists(stopka.IdStopki))
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
            return View(stopka);
        }

        // GET: Stopka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stopka == null)
            {
                return NotFound();
            }

            var stopka = await _context.Stopka
                .FirstOrDefaultAsync(m => m.IdStopki == id);
            if (stopka == null)
            {
                return NotFound();
            }

            return View(stopka);
        }

        // POST: Stopka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stopka == null)
            {
                return Problem("Entity set 'ProjektIntranetContext.Stopka'  is null.");
            }
            var stopka = await _context.Stopka.FindAsync(id);
            if (stopka != null)
            {
                _context.Stopka.Remove(stopka);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StopkaExists(int id)
        {
          return (_context.Stopka?.Any(e => e.IdStopki == id)).GetValueOrDefault();
        }
    }
}
