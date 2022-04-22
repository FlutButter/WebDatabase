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
    public class FishingOutsController : Controller
    {
        private readonly FishContext _context;

        public FishingOutsController(FishContext context)
        {
            _context = context;
        }

        // GET: FishingOuts
        public async Task<IActionResult> Index()
        {
            var fishContext = _context.FishingOuts.Include(f => f.Boat).Include(f => f.Team);
            return View(await fishContext.ToListAsync());
        }

        // GET: FishingOuts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingOut = await _context.FishingOuts
                .Include(f => f.Boat)
                .Include(f => f.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fishingOut == null)
            {
                return NotFound();
            }

            return View(fishingOut);
        }

        // GET: FishingOuts/Create
        public IActionResult Create()
        {
            ViewData["BoatId"] = new SelectList(_context.Boats, "Id", "Id");
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id");
            return View();
        }

        // POST: FishingOuts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateRelease,DateReturn,BoatId,TeamId")] FishingOut fishingOut)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fishingOut);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoatId"] = new SelectList(_context.Boats, "Id", "Id", fishingOut.BoatId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", fishingOut.TeamId);
            return View(fishingOut);
        }

        // GET: FishingOuts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingOut = await _context.FishingOuts.FindAsync(id);
            if (fishingOut == null)
            {
                return NotFound();
            }
            ViewData["BoatId"] = new SelectList(_context.Boats, "Id", "Id", fishingOut.BoatId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", fishingOut.TeamId);
            return View(fishingOut);
        }

        // POST: FishingOuts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateRelease,DateReturn,BoatId,TeamId")] FishingOut fishingOut)
        {
            if (id != fishingOut.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fishingOut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishingOutExists(fishingOut.Id))
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
            ViewData["BoatId"] = new SelectList(_context.Boats, "Id", "Id", fishingOut.BoatId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", fishingOut.TeamId);
            return View(fishingOut);
        }

        // GET: FishingOuts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingOut = await _context.FishingOuts
                .Include(f => f.Boat)
                .Include(f => f.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fishingOut == null)
            {
                return NotFound();
            }

            return View(fishingOut);
        }

        // POST: FishingOuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fishingOut = await _context.FishingOuts.FindAsync(id);
            _context.FishingOuts.Remove(fishingOut);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishingOutExists(int id)
        {
            return _context.FishingOuts.Any(e => e.Id == id);
        }
    }
}
