using Microsoft.AspNetCore.Mvc;
using CarShop.Web.ViewModels.Rental;
using CarShop.Data;
using Microsoft.EntityFrameworkCore;
using CarShop.Data.Models;
using System.Security.Claims;
using System.Collections.Specialized;

namespace CarShop.Web.Controllers
{
    public class RentalController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public RentalController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            Guid carGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref carGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction("Index", "Car");
            }

            var validCar = await _context.Cars
                .FirstOrDefaultAsync(c => c.Id == carGuid);
            if (validCar == null)
            {
                return this.RedirectToAction("Index", "Car");
            }

            var viewModel = new IndexRentalViewModel()
            {
                CarId = id,
                Make = validCar.Make,
                Model = validCar.Model,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(IndexRentalViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ConfirmRental", viewModel);
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmRental(IndexRentalViewModel viewModel)
        {
            Guid carGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(viewModel.CarId, ref carGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction("Index", "Car");
            }

            var validCar = await _context.Cars
                .FirstOrDefaultAsync(c => c.Id == carGuid);
            if (validCar == null)
            {
                return this.RedirectToAction("Index", "Car");
            }

            var totalRentDays = (viewModel.EndDate - viewModel.StartDate).Days + 1;
            var totalCost = totalRentDays * validCar.PricePerDay;

            var confirmViewModel = new ConfirmRentalViewModel()
            {
                CarId = viewModel.CarId,
                Make = validCar.Make,
                Model = validCar.Model,
                CarImage = validCar.CarImage ?? "/images/default-car.png",
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                TotalCost = totalCost,
            };

            return View(confirmViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmRent(ConfirmRentalViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Car");
            }

            Guid carGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(viewModel.CarId, ref carGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction("Index", "Car");
            }

            var validCar = await _context.Cars
                .FirstOrDefaultAsync(c => c.Id == carGuid);
            if (validCar == null)
            {
                return this.RedirectToAction("Index", "Car");
            }

            var userId = GetCurrentUserId();
            if (userId == Guid.Empty)
            {
                return this.RedirectToAction("Index", "Car");
            }

            validCar.IsAvailable = false;

            var rental = new Rental()
            {
                Id = Guid.NewGuid(),
                CarId = carGuid,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                TotalCost = viewModel.TotalCost
            };

            rental.ApplicationUserRentals.Add(new ApplicationUserRental()
            {
                ApplicationUserId = userId,
                RentalId = rental.Id
            });

            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(RentedCars));
        }

        [HttpGet]
        public async Task<IActionResult> RentedCars()
        {
            var userId = GetCurrentUserId();
            if (userId == Guid.Empty)
            {
                return this.RedirectToAction("Index", "Car");
            }

            var rentedCars = await _context.Rentals
                .Where(r => r.ApplicationUserRentals.Any(ur => ur.ApplicationUserId == userId))
                .Include(r => r.Car)
                .Select(r => new RentedCarViewModel()
                {
                    RentalId = r.Id,
                    Make = r.Car.Make,
                    Model = r.Car.Model,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    TotalCost = r.TotalCost,
                    CarImage = r.Car.CarImage ?? "/images/default-car.png"
                })
                .AsNoTracking()
                .ToListAsync();

            return View(rentedCars);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveRentedCar(Guid rentalId)
        {
            var userId = GetCurrentUserId();
            if (userId == Guid.Empty)
            {
                return this.RedirectToAction("Index", "Car");
            }

            var rental = await _context.Rentals
                .Include(r => r.Car)
                .FirstOrDefaultAsync(r => r.Id == rentalId);

            if (rental == null) 
            {
                return RedirectToAction(nameof(RentedCars));
            }

            var userRental = await _context.ApplicationsUsersRentals
                .FirstOrDefaultAsync(r => r.RentalId == rentalId);

            if (userRental == null)
            {
                return RedirectToAction(nameof(RentedCars));
            }

            rental.Car.IsAvailable = true;

            _context.ApplicationsUsersRentals.Remove(userRental);
            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(RentedCars));
        }


        private Guid GetCurrentUserId()
        {
            Guid userGuidId = Guid.Empty;
            bool isGuidValid = IsGuidValid(User.FindFirstValue(ClaimTypes.NameIdentifier), ref userGuidId);
            if (!isGuidValid)
            {
                return Guid.Empty;
            }
            return userGuidId;
        }
    }
}
