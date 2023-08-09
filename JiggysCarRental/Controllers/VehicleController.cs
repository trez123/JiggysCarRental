using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JiggysCarRental.Models;
using JiggysCarRental.Models.ViewModel;

namespace JiggysCarRental.Controllers
{
    public class VehicleController : Controller
    {
        private readonly CarDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VehicleController(CarDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Vehicle
        public async Task<IActionResult> Index()
        {
              return _context.Vehicles != null ? 
                          View(await _context.Vehicles.ToListAsync()) :
                          Problem("Entity set 'CarDbContext.Vehicles'  is null.");
        }

        // GET: Vehicle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }
            RentalViewModel RentalViewModel = new()
            {
                Vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id),
                Rental = new Rental()
            };

            if (RentalViewModel.Vehicle == null)
            {
                return NotFound();
            }

            return View(RentalViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int? id, RentalViewModel rentalViewModel)
        {
            RentalViewModel RentalViewModel = new()
            {
                Vehicle = await _context.Vehicles
                            .FirstOrDefaultAsync(m => m.Id == id),
                Rental = new Rental()
            };
            if (ModelState.IsValid)
            {
                Console.WriteLine("modelstate Valid");
                rentalViewModel.Rental.VehicleName = RentalViewModel.Vehicle.VehicleName;
                rentalViewModel.Rental.RentCost = RentalViewModel.Vehicle.RentCost;
                _context.Add(rentalViewModel.Rental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine("modelstate InValid");
            return View(RentalViewModel);
        }


        // GET: Vehicle/Edit/5
        public IActionResult Upsert(int id = 0)
        {
            if (id == 0)
            {
                var vehicle = new Vehicle
                {
                    StartDateAvailable = DateTime.Now,
                    EndDateAvailable = (DateTime.Now).AddDays(30)
                };
                return View(vehicle);
            }
            else
                return View(_context.Vehicles.Find(id));
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(int id,[Bind("Id,VehicleName,Image,Details,RentCost,NumberOfPassengers,NumberOLargeBags,UsbAdapter,ReverseCamera,PushStart,Bluetooth,ToolsControl,SteeringControl,ThermalControl,HeatedSeat,AutomaticTransmission,FourWheelDrive,LeatherSeats,Aux,StartDateAvailable,EndDateAvailable")] Vehicle vehicle)
        {

            if (ModelState.IsValid)
            {
                Console.WriteLine("Modelstate Valid");
                var files = HttpContext.Request.Form.Files;
                string webroot = _webHostEnvironment.WebRootPath;
                if (vehicle.Id == 0)
                {
                    string uploadpath = webroot + AppConst.UploadPath;
                    if (!Directory.Exists(uploadpath))
                    {
                        Directory.CreateDirectory(uploadpath);
                    }
                    string fileName = Guid.NewGuid().ToString();
                    string ext = Path.GetExtension(files[0].FileName);
                    using (var fs = new FileStream(Path.Combine(uploadpath, fileName + ext), FileMode.Create))
                    {
                        files[0].CopyTo(fs);
                    }
                    vehicle.Image = fileName + ext;
                    vehicle.StartDateAvailable = DateTime.Now;
                    _context.Add(vehicle);
                }
                else
                    _context.Update(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine("Modelstate Invalid");
            return View(vehicle);
        }

        // GET: Vehicle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehicles == null)
            {
                return Problem("Entity set 'CarDbContext.Vehicles'  is null.");
            }
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
          return (_context.Vehicles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
