using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrophyCaseDataBase.Data;
using TrophyCaseDataBase.Models;

namespace TrophyCaseDataBase.Controllers
{
    public class TrophiesController : Controller
    {
        private readonly TrophyCaseDataBaseContext _context;

        public TrophiesController(TrophyCaseDataBaseContext context)
        {
            _context = context;
        }

        // GET: Trophies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trophy.ToListAsync());
        }

        // GET: Trophies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trophy = await _context.Trophy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trophy == null)
            {
                return NotFound();
            }

            return View(trophy);
        }

        // GET: Trophies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trophies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,YearEarned,Details,ImagePath")] Trophy trophy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trophy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trophy);
        }

        // GET: Trophies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trophy = await _context.Trophy.FindAsync(id);
            if (trophy == null)
            {
                return NotFound();
            }
            return View(trophy);
        }

        // POST: Trophies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,YearEarned,Details,ImagePath")] Trophy trophy)
        {
            if (id != trophy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trophy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrophyExists(trophy.Id))
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
            return View(trophy);
        }

        // GET: Trophies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trophy = await _context.Trophy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trophy == null)
            {
                return NotFound();
            }

            return View(trophy);
        }

        // POST: Trophies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trophy = await _context.Trophy.FindAsync(id);
            _context.Trophy.Remove(trophy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrophyExists(int id)
        {
            return _context.Trophy.Any(e => e.Id == id);
        }
    }
}
