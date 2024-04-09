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
    public class BillsController : Controller
    {
        private readonly QLDBcontext _context;

        public BillsController(QLDBcontext context)
        {
            _context = context;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
              return _context.Bills != null ? 
                          View(await _context.Bills.ToListAsync()) :
                          Problem("Entity set 'QLDBcontext.Bills'  is null.");
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bills == null)
            {
                return NotFound();
            }

            var Bills = await _context.Bills
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Bills == null)
            {
                return NotFound();
            }

            return View(Bills);
        }

        // GET: Bills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDBooking,TotalAmount,IDAccount")] Bill Bills)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Bills);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Bills);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bills == null)
            {
                return NotFound();
            }

            var Bills = await _context.Bills.FindAsync(id);
            if (Bills == null)
            {
                return NotFound();
            }
            return View(Bills);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDBooking,TotalAmount,IDAccount")] Bill Bills)
        {
            if (id != Bills.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Bills);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillsExists(Bills.ID))
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
            return View(Bills);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bills == null)
            {
                return NotFound();
            }

            var Bills = await _context.Bills
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Bills == null)
            {
                return NotFound();
            }

            return View(Bills);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bills == null)
            {
                return Problem("Entity set 'BTLONKY5Context.Bills'  is null.");
            }
            var Bills = await _context.Bills.FindAsync(id);
            if (Bills != null)
            {
                _context.Bills.Remove(Bills);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillsExists(int id)
        {
          return (_context.Bills?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
