#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCdCollection.Data;
using MvcCdCollection.Models;

namespace MvcCdCollection.Controllers
{
    public class CDsController : Controller
    {
        private readonly MvcCdCollectionContext _context;

        public CDsController(MvcCdCollectionContext context)
        {
            _context = context;
        }

        // GET: CDs
        public async Task<IActionResult> Index(string searchString)
        {
            var cds = from c in _context.PreachingCDs
                      select c;
            if (!string.IsNullOrEmpty(searchString))
            {
                cds = cds.Where(s => s.Title!.Contains(searchString));
            }

            return View(await cds.ToListAsync());
        }

        // GET: CDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preachingCDs = await _context.PreachingCDs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (preachingCDs == null)
            {
                return NotFound();
            }

            return View(preachingCDs);
        }

        // GET: CDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author")] PreachingCDs preachingCDs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preachingCDs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(preachingCDs);
        }

        // GET: CDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preachingCDs = await _context.PreachingCDs.FindAsync(id);
            if (preachingCDs == null)
            {
                return NotFound();
            }
            return View(preachingCDs);
        }

        // POST: CDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author")] PreachingCDs preachingCDs)
        {
            if (id != preachingCDs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preachingCDs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreachingCDsExists(preachingCDs.Id))
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
            return View(preachingCDs);
        }

        // GET: CDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preachingCDs = await _context.PreachingCDs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (preachingCDs == null)
            {
                return NotFound();
            }

            return View(preachingCDs);
        }

        // POST: CDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preachingCDs = await _context.PreachingCDs.FindAsync(id);
            _context.PreachingCDs.Remove(preachingCDs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreachingCDsExists(int id)
        {
            return _context.PreachingCDs.Any(e => e.Id == id);
        }
    }
}
