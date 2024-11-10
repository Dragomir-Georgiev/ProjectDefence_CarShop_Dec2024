using CarShop.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CarShop.Data.Models;
using CarShop.Web.ViewModels.Car;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return this.RedirectToAction(nameof(Index));
            }

            Guid carGuid = Guid.Empty;
            bool isGuidValid = Guid.TryParse(id, out carGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            CarDetailsViewModel? carModel = await _context
                .Cars
                .Where(c => c.IsDeleted == false && c.IsAvailable == true)
                .Select(c => new CarDetailsViewModel()
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    ProductionYear = c.ProductionYear,
                    FuelConsumption = c.FuelConsumption,
                    TankVolume = c.TankVolume,
                    MaximumSpeed = c.MaximumSpeed,
                    DoorsCount = c.DoorsCount,
                    SeatingCapacity = c.SeatingCapacity,
                    TransmissionType = c.TransmissionType,
                    PricePerDay = c.PricePerDay,
                    CategoryName = c.CarCategory.CategoryName,
                    CarImage = c.CarImage
                })
                .FirstOrDefaultAsync(c => c.Id == carGuid);

            if (carModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(carModel);
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
