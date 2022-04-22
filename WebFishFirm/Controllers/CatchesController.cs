using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fishfirm;

namespace WebFishFirm.Controllers
{
    public class CatchesController : Controller
    {
        private readonly FishContext _context;

        public CatchesController(FishContext context)
        {
            _context = context;
        }

        // GET: Catches
        public async Task<IActionResult> Index()
        {
            var fishContext = _context.Catches.Include(@f => @f.Fish).Include(@f => @f.VisitFishPlace);
            return View(await fishContext.ToListAsync());
        }

        // GET: Catches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @catch = await _context.Catches
                .Include(@f => @f.Fish)
                .Include(@f => @f.VisitFishPlace)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@catch == null)
            {
                return NotFound();
            }

            return View(@catch);
        }

        // GET: Catches/Create
        public IActionResult Create()
        {
            ViewData["FishId"] = new SelectList(_context.Fish, "Id", "Id");
            ViewData["VisitFishPlaceId"] = new SelectList(_context.VisitFishPlaces, "Id", "Id");
            return View();
        }

        // POST: Catches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Weight,VisitFishPlaceId,FishId")] Catch @catch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@catch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FishId"] = new SelectList(_context.Fish, "Id", "Id", @catch.FishId);
            ViewData["VisitFishPlaceId"] = new SelectList(_context.VisitFishPlaces, "Id", "Id", @catch.VisitFishPlaceId);
            return View(@catch);
        }

        // GET: Catches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @catch = await _context.Catches.FindAsync(id);
            if (@catch == null)
            {
                return NotFound();
            }
            ViewData["FishId"] = new SelectList(_context.Fish, "Id", "Id", @catch.FishId);
            ViewData["VisitFishPlaceId"] = new SelectList(_context.VisitFishPlaces, "Id", "Id", @catch.VisitFishPlaceId);
            return View(@catch);
        }

        // POST: Catches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Weight,VisitFishPlaceId,FishId")] Catch @catch)
        {
            if (id != @catch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@catch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatchExists(@catch.Id))
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
            ViewData["FishId"] = new SelectList(_context.Fish, "Id", "Id", @catch.FishId);
            ViewData["VisitFishPlaceId"] = new SelectList(_context.VisitFishPlaces, "Id", "Id", @catch.VisitFishPlaceId);
            return View(@catch);
        }

        // GET: Catches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @catch = await _context.Catches
                .Include(@f => @f.Fish)
                .Include(@f => @f.VisitFishPlace)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@catch == null)
            {
                return NotFound();
            }

            return View(@catch);
        }

        // POST: Catches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @catch = await _context.Catches.FindAsync(id);
            _context.Catches.Remove(@catch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatchExists(int id)
        {
            return _context.Catches.Any(e => e.Id == id);
        }
    }
}
