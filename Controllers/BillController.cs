﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLONKY5.Data;
using BTLONKY5.Models;

namespace BTLONKY5.Controllers
{
    public class BillController : Controller
    {
        private readonly BTLONKY5Context _context;

        public BillController(BTLONKY5Context context)
        {
            _context = context;
        }

        // GET: Bill
        public async Task<IActionResult> Index()
        {
              return _context.Bill != null ? 
                          View(await _context.Bill.ToListAsync()) :
                          Problem("Entity set 'BTLONKY5Context.Bill'  is null.");
        }

        // GET: Bill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bill == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bill/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bill/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDBooking,TotalAmount,IDAccount")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bill);
        }

        // GET: Bill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bill == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            return View(bill);
        }

        // POST: Bill/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDBooking,TotalAmount,IDAccount")] Bill bill)
        {
            if (id != bill.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillExists(bill.ID))
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
            return View(bill);
        }

        // GET: Bill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bill == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bill == null)
            {
                return Problem("Entity set 'BTLONKY5Context.Bill'  is null.");
            }
            var bill = await _context.Bill.FindAsync(id);
            if (bill != null)
            {
                _context.Bill.Remove(bill);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillExists(int id)
        {
          return (_context.Bill?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
