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
    public class FishPlacesController : Controller
    {
        private readonly FishContext _context;

        public FishPlacesController(FishContext context)
        {
            _context = context;
        }

        // GET: FishPlaces
        public async Task<IActionResult> Index()
        {
            return View(await _context.FishPlaces.ToListAsync());
        }

        // GET: FishPlaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishPlace = await _context.FishPlaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fishPlace == null)
            {
                return NotFound();
            }

            return View(fishPlace);
        }

        // GET: FishPlaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FishPlaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FishPlace fishPlace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fishPlace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fishPlace);
        }

        // GET: FishPlaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishPlace = await _context.FishPlaces.FindAsync(id);
            if (fishPlace == null)
            {
                return NotFound();
            }
            return View(fishPlace);
        }

        // POST: FishPlaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FishPlace fishPlace)
        {
            if (id != fishPlace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fishPlace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishPlaceExists(fishPlace.Id))
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
            return View(fishPlace);
        }

        // GET: FishPlaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishPlace = await _context.FishPlaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fishPlace == null)
            {
                return NotFound();
            }

            return View(fishPlace);
        }

        // POST: FishPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fishPlace = await _context.FishPlaces.FindAsync(id);
            _context.FishPlaces.Remove(fishPlace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishPlaceExists(int id)
        {
            return _context.FishPlaces.Any(e => e.Id == id);
        }
    }
}
