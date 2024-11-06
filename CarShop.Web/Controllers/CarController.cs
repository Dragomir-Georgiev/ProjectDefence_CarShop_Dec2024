using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Web.ViewModels.Car;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarShop.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cars = await _context.Cars
                .Where(c => c.IsDeleted == false && c.IsAvailable == true)
                .Select(c => new AllCarsIndexViewModel()
                {
                    Id = c.Id.ToString(),
                    Make = c.Make,
                    Model = c.Model,
                    CarImage = c.CarImage,
                    PricePerDay = c.PricePerDay.ToString(),
                })
                .AsNoTracking()
                .ToListAsync();
            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddCarViewModel();

            model.CarCategories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarViewModel carModel)
        {
            if (!ModelState.IsValid)
            {
                carModel.CarCategories = await GetCategories();
                return View(carModel);
            }

            Car car = new Car()
            {
                Make = carModel.Make,
                Model = carModel.Model,
                CarCategoryId = carModel.CarCategoryId,
                TransmissionType = carModel.TransmissionType,
                PricePerDay = carModel.PricePerDay,
                MaximumSpeed = carModel.MaximumSpeed,
                CarImage = carModel.CarImage,
                DoorsCount = carModel.DoorsCount,
                FuelConsumption = carModel.FuelConsumption,
                ProductionYear = carModel.ProductionYear,
                SeatingCapacity = carModel.SeatingCapacity,
                TankVolume = carModel.TankVolume,
                IsAvailable = true,
            };

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<List<CarCategory>> GetCategories()
        {
            return await _context.CarCategories.ToListAsync();
        }
    }
}
