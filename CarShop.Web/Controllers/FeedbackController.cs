using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services.Data.Interfaces;
using CarShop.Web.Infrastructure.Extensions;
using CarShop.Web.ViewModels.Feedback;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarShop.Web.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid carId)
        {
            var userId = GetCurrentUserId();
            if (userId == Guid.Empty)
            {
                return this.RedirectToAction("Index", "Car");
            }

            var viewModel= await _feedbackService.GetFeedbacksByCarIdAsync(carId, userId);
            if (viewModel == null)
            {
                return this.RedirectToAction("Index", "Car");
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddFeedback(Guid carId)
        {
            var viewModel = new AddFeedbackViewModel
            {
                CarId = carId,
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback(AddFeedbackViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var userId = GetCurrentUserId();
            if (userId == Guid.Empty)
            {
                return this.RedirectToAction("Index", "Car");
            }

            bool result = await _feedbackService.AddFeedbackAsync(viewModel, userId);
            if (result == false)
            {
                this.ModelState.AddModelError(nameof(viewModel.CarId),"Invalide car Id");
                return this.RedirectToAction("Index", "Car");
            }

            return RedirectToAction("Index", new { carId = viewModel.CarId });
        }

        [HttpGet]
        public async Task<IActionResult> EditFeedback(Guid id)
        {
            var userId = GetCurrentUserId();
            if (userId == Guid.Empty)
            {
                return this.RedirectToAction("Index", "Car");
            }

            var viewModel = await _feedbackService.GetFeedbackForEditAsync(id, userId);
            if (viewModel == null)
            {
                this.ModelState.AddModelError(nameof(viewModel.Id), "You do not have permission to edit this feedback.");
                return this.RedirectToAction("Index", "Car");
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditFeedback(AddFeedbackViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            var userId = GetCurrentUserId();
            if (userId == Guid.Empty)
            {
                return this.RedirectToAction("Index", "Car");
            }
            bool result = await _feedbackService.EditFeedbackAsync(form, userId);
            if (result == false)
            {
                this.ModelState.AddModelError(nameof(form.Id), "You do not have permission to edit this feedback.");
                return this.RedirectToAction("Index", "Car");
            }

            return RedirectToAction("Index", new { carId = form.CarId });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFeedback(Guid id)
        {
            var userId = GetCurrentUserId();
            if (userId == Guid.Empty)
            {
                return this.RedirectToAction("Index", "Car");
            }

            bool result = await _feedbackService.RemoveFeedbackAsync(id, userId);
            if (result == false)
            {
                this.ModelState.AddModelError(nameof(userId), "You do not have permission to edit this feedback.");
                return this.RedirectToAction("Index", "Car");
            }

            return this.RedirectToAction("Index", "Car");
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
