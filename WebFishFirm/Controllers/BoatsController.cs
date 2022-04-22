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
    public class BoatsController : Controller
    {
        private readonly FishContext _context;

        public BoatsController(FishContext context)
        {
            _context = context;
        }

        // GET: Boats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boats.ToListAsync());
        }

        // GET: Boats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = await _context.Boats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // GET: Boats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Displacement,DateConstruct")] Boat boat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boat);
        }

        // GET: Boats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = await _context.Boats.FindAsync(id);
            if (boat == null)
            {
                return NotFound();
            }
            return View(boat);
        }

        // POST: Boats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Displacement,DateConstruct")] Boat boat)
        {
            if (id != boat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoatExists(boat.Id))
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
            return View(boat);
        }

        // GET: Boats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = await _context.Boats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // POST: Boats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boat = await _context.Boats.FindAsync(id);
            _context.Boats.Remove(boat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoatExists(int id)
        {
            return _context.Boats.Any(e => e.Id == id);
        }
    }
}
