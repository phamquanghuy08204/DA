using System;
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
    public class BookingController : Controller
    {
        private readonly BTLONKY5Context _context;

        public BookingController(BTLONKY5Context context)
        {
            _context = context;
        }

        // GET: Booking

        public async Task<IActionResult> Booking()
        {
            return View();
        } 
				
		public async Task<IActionResult> Index()
        {
              return _context.Booking != null ? 
                          View(await _context.Booking.ToListAsync()) :
                          Problem("Entity set 'BTLONKY5Context.Booking'  is null.");
        }

        // GET: Booking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .FirstOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDTable,IDAccount,NameBooking,sdtBooking,Date,Checkin,Checkout,SdtBooking,IDFood")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Booking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDTable,IDAccount,NameBooking,sdtBooking,Date,Checkin,Checkout,SdtBooking,IDFood")] Booking booking)
        {
            if (id != booking.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.ID))
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
            return View(booking);
        }

        // GET: Booking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .FirstOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Booking == null)
            {
                return Problem("Entity set 'BTLONKY5Context.Booking'  is null.");
            }
            var booking = await _context.Booking.FindAsync(id);
            if (booking != null)
            {
                _context.Booking.Remove(booking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
          return (_context.Booking?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
