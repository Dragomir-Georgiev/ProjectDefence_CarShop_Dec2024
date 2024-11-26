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
using Microsoft.AspNetCore.Mvc.Rendering;

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
            AddCarViewModel model = await _carService.GetCategoriesFromAddCarViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCarViewModel carModel)
        {
            if (!ModelState.IsValid)
            {
                carModel.CarCategories = (await _carService.GetCategoriesFromAddCarViewModel()).CarCategories;
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
            var model = await _carService.GetEditCarModelAsync(carGuid);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarViewModel carModel, string? id)
        {
            //TODO: Make a CarCategory Service to load the categories through it and not through the Car ViewModels. Change here and in the add action
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

            await _carService.UpdateCarAsync(carGuid, carModel);

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
        private async Task<List<SelectListItem>> GetCategories()
        {
            return await _context.CarCategories
                .AsQueryable()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName
                })
                .ToListAsync();
        }
    }
}
