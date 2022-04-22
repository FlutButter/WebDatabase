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
    public class FishController : Controller
    {
        private readonly FishContext _context;

        public FishController(FishContext context)
        {
            _context = context;
        }

        // GET: Fish
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fish.ToListAsync());
        }

        // GET: Fish/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await _context.Fish
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // GET: Fish/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fish/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kind")] Fish fish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fish);
        }

        // GET: Fish/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await _context.Fish.FindAsync(id);
            if (fish == null)
            {
                return NotFound();
            }
            return View(fish);
        }

        // POST: Fish/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kind")] Fish fish)
        {
            if (id != fish.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishExists(fish.Id))
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
            return View(fish);
        }

        // GET: Fish/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await _context.Fish
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // POST: Fish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fish = await _context.Fish.FindAsync(id);
            _context.Fish.Remove(fish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishExists(int id)
        {
            return _context.Fish.Any(e => e.Id == id);
        }
    }
}
