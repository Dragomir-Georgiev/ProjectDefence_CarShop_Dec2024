using CarShop.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CarShop.Data.Models;
using CarShop.Web.ViewModels.Car;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using System.Globalization;
using CarShop.Services.Data.Interfaces;

namespace CarShop.Web.Controllers
{
    public class CarController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarService _carService;
        public CarController(ApplicationDbContext context, ICarService carService)
        {
            _context = context;
            _carService = carService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllCarsIndexViewModel> cars = 
                await _carService.IndexGetAllAsync(); 
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
            
            await _carService.AddCarAsync(carModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid carGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref carGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            CarDetailsViewModel? viewModel = await 
                _carService.GetCarDetailsByIdAsync(carGuid);

            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            Guid carGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref carGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }
            var model = await _context.Cars
                .Where(c => c.IsDeleted == false)
                .Where(c => c.Id == carGuid)
                .AsNoTracking()
                .Select(c => new EditCarViewModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    CarCategoryId = c.CarCategoryId,
                    TransmissionType = c.TransmissionType,
                    PricePerDay = c.PricePerDay,
                    MaximumSpeed = c.MaximumSpeed,
                    CarImage = c.CarImage,
                    DoorsCount = c.DoorsCount,
                    FuelConsumption = c.FuelConsumption,
                    ProductionYear = c.ProductionYear,
                    SeatingCapacity = c.SeatingCapacity,
                    TankVolume = c.TankVolume,
                })
                .FirstOrDefaultAsync();

            model!.CarCategories = await GetCategories();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarViewModel carModel, string? id)
        {
            if (!ModelState.IsValid)
            {
                carModel!.CarCategories = await GetCategories();
                return View(carModel);
            }

            Guid carGuid = Guid.Empty;
            bool isGuidValid =  IsGuidValid(id, ref carGuid);
            if (!isGuidValid)
            {
                carModel!.CarCategories = await GetCategories();
                return View(carModel);
            }

            Car? entity = await _context.Cars.FindAsync(carGuid);

            if (entity == null || entity.IsDeleted)
            {
                return BadRequest();
            }

            entity.Make = carModel.Make;
            entity.Model = carModel.Model;
            entity.ProductionYear = carModel.ProductionYear;
            entity.FuelConsumption = carModel.FuelConsumption;
            entity.TankVolume = carModel.TankVolume;
            entity.MaximumSpeed = carModel.MaximumSpeed;
            entity.CarImage = carModel.CarImage;
            entity.DoorsCount = carModel.DoorsCount;
            entity.SeatingCapacity = carModel.SeatingCapacity;
            entity.TransmissionType = carModel.TransmissionType;
            entity.PricePerDay = carModel.PricePerDay;
            entity.CarCategoryId = carModel.CarCategoryId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            Guid carGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref carGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Car? car = await _context.Cars
                .Where(c => c.IsDeleted == false)
                .Include(c => c.CarCategory)
                .FirstOrDefaultAsync(c => c.Id == carGuid);

            if (car == null) 
            {
                return this.RedirectToAction(nameof(Index));
            }

            DeleteCarViewModel entity = new DeleteCarViewModel()
            {
                Id = car.Id.ToString(),
                Model = car.Model,
                Make = car.Make,
                CategoryName = car.CarCategory.CategoryName
            };

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DeleteCarViewModel carModel)
        {
            Guid carGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(carModel.Id, ref carGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Car? car = await _context.Cars
                .Where(c => c.IsDeleted == false)
                .Where(c => c.Id == carGuid)
                .FirstOrDefaultAsync();

            if (car != null)
            {
                car.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

            return this.RedirectToAction(nameof(Index));
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
