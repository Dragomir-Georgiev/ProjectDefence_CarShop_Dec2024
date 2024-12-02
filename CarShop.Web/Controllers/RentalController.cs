using Microsoft.AspNetCore.Mvc;
using CarShop.Web.ViewModels.Rental;
using CarShop.Data;
using Microsoft.EntityFrameworkCore;
using CarShop.Data.Models;
using System.Security.Claims;
using System.Collections.Specialized;
using CarShop.Services.Data.Interfaces;
using CarShop.Web.Infrastructure.Extensions;

namespace CarShop.Web.Controllers
{
    public class RentalController : BaseController
    {
        private readonly IRentalService _rentalService;
        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
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

            var viewModel = await _rentalService.GetRentalIndexAsync(carGuid);
            if (viewModel == null)
            {
                return this.RedirectToAction("Index", "Car");
            }

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(IndexRentalViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            return RedirectToAction("ConfirmRental", viewModel);
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

            var confirmViewModel = await _rentalService.GetConfirmRentalIndexAsync(viewModel, carGuid);
            if (confirmViewModel == null)
            {
                return this.RedirectToAction("Index", "Car");
            }

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

            var userId = GetCurrentUserId();
            if (userId == Guid.Empty)
            {
                return this.RedirectToAction("Index", "Car");
            }

            bool result = await _rentalService.AddRentalAsync(viewModel, userId, carGuid);
            if (result == false)
            {
                this.ModelState.AddModelError(nameof(viewModel.CarId), "Invalide car Id");
                return this.RedirectToAction("Index", "Car");
            }
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

            var rentedCars = await _rentalService.GetRentedCarsAsync(userId);
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

            bool result = await _rentalService.RemoveRentalAsync(rentalId, userId);
            if (result == false) 
            {
                this.ModelState.AddModelError(nameof(userId), "You do not have permission to remove this rental.");
                return this.RedirectToAction("Index", "Car");
            }

            return RedirectToAction(nameof(RentedCars));
        }

        private Guid GetCurrentUserId()
        {
            Guid userGuidId = Guid.Empty;
            bool isGuidValid = IsGuidValid(User.GetUserId(), ref userGuidId);
            if (!isGuidValid)
            {
                return Guid.Empty;
            }
            return userGuidId;
        }
    }
}
