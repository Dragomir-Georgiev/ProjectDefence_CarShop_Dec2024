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
using CarShop.Web.ViewModels.CarCategories;
using CarShop.Services.Data;
using Microsoft.AspNetCore.Authorization;
using static CarShop.Common.ApplicationConstants;

namespace CarShop.Web.Controllers
{
	public class CarController : BaseController
	{
		private readonly ICarService _carService;
		private readonly ICarCategoryService _carCategotyService;
		public CarController(ApplicationDbContext context, ICarService carService, ICarCategoryService carCategotyService)
		{
			_carService = carService;
			_carCategotyService = carCategotyService;
		}
		[HttpGet]
		public async Task<IActionResult> Index(AllCarSearchFilterViewModel inputModel)
		{
			IEnumerable<AllCarsIndexViewModel> cars =
				await _carService.IndexGetAllAsync(inputModel);
			int allCarsCount = await _carService.GetCarsCountByFilterAsync(inputModel);
			AllCarSearchFilterViewModel viewModel = new AllCarSearchFilterViewModel()
			{
				Cars = cars,
				SearchQuery = inputModel.SearchQuery,
			    PriceFilter = inputModel.PriceFilter,
				CurrentPage = inputModel.CurrentPage,
				TotalPages = (int)Math.Ceiling((double)allCarsCount /
											   inputModel.EntitiesPerPage!.Value)
			};

			return View(viewModel);
		}
		[HttpGet]
		[Authorize(Roles = $"{ManagerRoleName},{AdminRoleName}")]
		public async Task<IActionResult> Add()
		{
			AddCarViewModel model = await _carService.GetCarCategoriesAsync();
			return View(model);
		}
		[HttpPost]
		[Authorize(Roles = $"{ManagerRoleName},{AdminRoleName}")]
		public async Task<IActionResult> Add(AddCarViewModel carModel)
		{
			if (!ModelState.IsValid)
			{
				carModel.CarCategories = await _carCategotyService.GetCarCategoriesAsync();
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
		[Authorize(Roles = $"{ManagerRoleName},{AdminRoleName}")]
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
		[Authorize(Roles = $"{ManagerRoleName},{AdminRoleName}")]
		public async Task<IActionResult> Edit(EditCarViewModel carModel, string? id)
		{
			if (!ModelState.IsValid)
			{
				carModel!.CarCategories = await _carCategotyService.GetCarCategoriesAsync();
				return View(carModel);
			}

			Guid carGuid = Guid.Empty;
			bool isGuidValid = IsGuidValid(id, ref carGuid);
			if (!isGuidValid)
			{
				carModel!.CarCategories = await _carCategotyService.GetCarCategoriesAsync();
				return View(carModel);
			}

			await _carService.UpdateCarAsync(carGuid, carModel);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize(Roles = $"{ManagerRoleName},{AdminRoleName}")]
		public async Task<IActionResult> Delete(string id)
		{
			Guid carGuid = Guid.Empty;
			bool isGuidValid = IsGuidValid(id, ref carGuid);
			if (!isGuidValid)
			{
				return this.RedirectToAction(nameof(Index));
			}

			DeleteCarViewModel? carViewModel = await _carService.GetDeleteCarModelAsync(carGuid);

			if (carViewModel == null)
			{
				return this.RedirectToAction(nameof(Index));
			}

			return View(carViewModel);
		}

		[HttpPost]
		[Authorize(Roles = $"{ManagerRoleName},{AdminRoleName}")]
		public async Task<IActionResult> DeleteConfirmed(DeleteCarViewModel carModel)
		{
			Guid carGuid = Guid.Empty;
			bool isGuidValid = IsGuidValid(carModel.Id, ref carGuid);
			if (!isGuidValid)
			{
				return this.RedirectToAction(nameof(Index));
			}

			await _carService.SoftDeleteCarAsync(carGuid);

			return this.RedirectToAction(nameof(Index));
		}
	}
}
