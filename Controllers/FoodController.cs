using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLONKY5.Models;

namespace BTLONKY5.Controllers
{
    public class FoodController : Controller
    {
        private readonly QLDBcontext _context;

        public FoodController(QLDBcontext context)
        {
            _context = context;
        }

		// GET: Food

		public async Task<IActionResult> Menu(int TableId)
		{
			return View();
		}

		public async Task<IActionResult> Index()
        {
              return _context.Foods != null ? 
                          View(await _context.Foods.ToListAsync()) :
                          Problem("Entity set 'QLDBcontext.Foods'  is null.");
        }

        // GET: Food/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Foods == null)
            {
                return NotFound();
            }

            var food = await _context.Foods
                .FirstOrDefaultAsync(m => m.ID == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // GET: Food/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Food/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NameFood,IDCategory,ImgFood,Description,PriceFood")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Add(food);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        // GET: Food/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Foods == null)
            {
                return NotFound();
            }

            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // POST: Food/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NameFood,IDCategory,ImgFood,Description,PriceFood")] Food food)
        {
            if (id != food.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(food);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodExists(food.ID))
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
            return View(food);
        }

        // GET: Food/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Foods == null)
            {
                return NotFound();
            }

            var food = await _context.Foods
                .FirstOrDefaultAsync(m => m.ID == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Foods == null)
            {
                return Problem("Entity set 'QLDBcontext.Foods'  is null.");
            }
            var food = await _context.Foods.FindAsync(id);
            if (food != null)
            {
                _context.Foods.Remove(food);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodExists(int id)
        {
          return (_context.Foods?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
