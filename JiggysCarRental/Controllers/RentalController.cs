using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JiggysCarRental.Models;

namespace JiggysCarRental.Controllers
{
    public class RentalController : Controller
    {
        private readonly CarDbContext _context;

        public RentalController(CarDbContext context)
        {
            _context = context;
        }

        // GET: Rental
        public async Task<IActionResult> Index()
        {
              return _context.Rentals != null ? 
                          View(await _context.Rentals.ToListAsync()) :
                          Problem("Entity set 'CarDbContext.Rentals'  is null.");
        }

        // GET: Rental/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rental/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rental/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,VehicleName,RentCost,PickupDate,ReturnDate,GPSNavigation,InfantAndChildSeats")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rental);
        }

        // GET: Rental/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }

        // POST: Rental/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,VehicleName,RentCost,PickupDate,ReturnDate,GPSNavigation,InfantAndChildSeats")] Rental rental)
        {
            if (id != rental.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.TransactionId))
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
            return View(rental);
        }

        // GET: Rental/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rental/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rentals == null)
            {
                return Problem("Entity set 'CarDbContext.Rentals'  is null.");
            }
            var rental = await _context.Rentals.FindAsync(id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(int id)
        {
          return (_context.Rentals?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
