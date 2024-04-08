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
    public class TableController : Controller
    {
        private readonly QLDBcontext _context;

        public TableController(QLDBcontext context)
        {
            _context = context;
        }

        // GET: Table
        public async Task<IActionResult> BookingTable()
        {
            return View();
        }

		[HttpPost]
		public ActionResult OrderFood(int tableId)
		{
			// Xử lý logic tại đây (ví dụ: chuyển hướng, xử lý dữ liệu, ...)
			return RedirectToAction("Menu", "Food"); // Chuyển hướng đến action khác nếu cần
		}

		public async Task<IActionResult> Index()
        {
              return _context.Tables != null ? 
                          View(await _context.Tables.ToListAsync()) :
                          Problem("Entity set 'QLDBcontext.Tables'  is null.");
        }

        // GET: Table/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tables == null)
            {
                return NotFound();
            }

            var table = await _context.Tables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }

        // GET: Table/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,Capacity")] Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Add(table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(table);
        }

        // GET: Table/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tables == null)
            {
                return NotFound();
            }

            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        // POST: Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,Capacity")] Table table)
        {
            if (id != table.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(table);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableExists(table.Id))
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
            return View(table);
        }

        // GET: Table/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tables == null)
            {
                return NotFound();
            }

            var table = await _context.Tables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }

        // POST: Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tables == null)
            {
                return Problem("Entity set 'QLDBcontext.Tables'  is null.");
            }
            var table = await _context.Tables.FindAsync(id);
            if (table != null)
            {
                _context.Tables.Remove(table);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableExists(int id)
        {
          return (_context.Tables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
