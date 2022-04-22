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
    public class VisitFishPlacesController : Controller
    {
        private readonly FishContext _context;

        public VisitFishPlacesController(FishContext context)
        {
            _context = context;
        }

        // GET: VisitFishPlaces
        public async Task<IActionResult> Index()
        {
            var fishContext = _context.VisitFishPlaces.Include(v => v.FishPlace).Include(v => v.FishingOut);
            return View(await fishContext.ToListAsync());
        }

        // GET: VisitFishPlaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitFishPlace = await _context.VisitFishPlaces
                .Include(v => v.FishPlace)
                .Include(v => v.FishingOut)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitFishPlace == null)
            {
                return NotFound();
            }

            return View(visitFishPlace);
        }

        // GET: VisitFishPlaces/Create
        public IActionResult Create()
        {
            ViewData["FishPlaceId"] = new SelectList(_context.FishPlaces, "Id", "Id");
            ViewData["FishingOutId"] = new SelectList(_context.FishingOuts, "Id", "Id");
            return View();
        }

        // POST: VisitFishPlaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateIn,DateOut,Quality,FishingOutId,FishPlaceId")] VisitFishPlace visitFishPlace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitFishPlace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FishPlaceId"] = new SelectList(_context.FishPlaces, "Id", "Id", visitFishPlace.FishPlaceId);
            ViewData["FishingOutId"] = new SelectList(_context.FishingOuts, "Id", "Id", visitFishPlace.FishingOutId);
            return View(visitFishPlace);
        }

        // GET: VisitFishPlaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitFishPlace = await _context.VisitFishPlaces.FindAsync(id);
            if (visitFishPlace == null)
            {
                return NotFound();
            }
            ViewData["FishPlaceId"] = new SelectList(_context.FishPlaces, "Id", "Id", visitFishPlace.FishPlaceId);
            ViewData["FishingOutId"] = new SelectList(_context.FishingOuts, "Id", "Id", visitFishPlace.FishingOutId);
            return View(visitFishPlace);
        }

        // POST: VisitFishPlaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateIn,DateOut,Quality,FishingOutId,FishPlaceId")] VisitFishPlace visitFishPlace)
        {
            if (id != visitFishPlace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitFishPlace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitFishPlaceExists(visitFishPlace.Id))
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
            ViewData["FishPlaceId"] = new SelectList(_context.FishPlaces, "Id", "Id", visitFishPlace.FishPlaceId);
            ViewData["FishingOutId"] = new SelectList(_context.FishingOuts, "Id", "Id", visitFishPlace.FishingOutId);
            return View(visitFishPlace);
        }

        // GET: VisitFishPlaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitFishPlace = await _context.VisitFishPlaces
                .Include(v => v.FishPlace)
                .Include(v => v.FishingOut)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitFishPlace == null)
            {
                return NotFound();
            }

            return View(visitFishPlace);
        }

        // POST: VisitFishPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitFishPlace = await _context.VisitFishPlaces.FindAsync(id);
            _context.VisitFishPlaces.Remove(visitFishPlace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitFishPlaceExists(int id)
        {
            return _context.VisitFishPlaces.Any(e => e.Id == id);
        }
    }
}
