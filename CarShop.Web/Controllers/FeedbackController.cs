using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Web.ViewModels.Feedback;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarShop.Web.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid carId)
        {
            var validCar = await _context.Cars
                .FirstOrDefaultAsync(c => c.Id == carId);
            if (validCar == null)
            {
                return this.RedirectToAction("Index", "Car");
            }

            var userId = GetCurrentUserId();
            if (userId == Guid.Empty)
            {
                return this.RedirectToAction("Index", "Car");
            }

            var feedbacks = await _context.Feedbacks
                .Where(f => f.CarId == carId)
                .Select(f => new FeedbackViewModel()
                {
                    Id = f.Id,
                    Comment = f.Comment,
                    FeedbackDate = f.FeedbackDate,
                    Rating = f.Rating,
                    UserName = f.ApplicationUser.UserName ?? string.Empty,
                    IsOwner = f.ApplicationUser.Id == userId,
                })
                .ToListAsync();

            var viewModel = new IndexFeedbackViewModel()
            {
                CarId = carId,
                CarMakeModel = $"{validCar.Make} {validCar.Model}",
                Feedbacks = feedbacks,
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddFeedback(Guid carId)
        {
            var viewModel = new FeedbackFormViewModel
            {
                CarId = carId,
                
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback(FeedbackFormViewModel viewModel)
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

            var feedback = new Feedback()
            {
                Comment = viewModel.Comment,
                FeedbackDate = DateTime.Now,
                Rating = viewModel.Rating,
                CarId = viewModel.CarId,
                ApplicationUserId = userId,
            };

            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { carId = viewModel.CarId });
        }

        [HttpGet]
        public async Task<IActionResult> EditFeedback(Guid id)
        {
            var feedback = await _context.Feedbacks
                .FirstOrDefaultAsync(f => f.Id == id);

            var userId = GetCurrentUserId();
            if (userId == Guid.Empty)
            {
                return this.RedirectToAction("Index", "Car");
            }

            if (feedback == null || feedback.ApplicationUserId != userId)
            {
                return RedirectToAction("Index", new { carId = feedback!.CarId });
            }

            var viewModel = new FeedbackFormViewModel
            {
                Id = feedback.Id,
                CarId = feedback.CarId,
                Comment = feedback.Comment,
                Rating = feedback.Rating
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditFeedback(FeedbackFormViewModel form)
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

            var feedback = await _context.Feedbacks
                .FirstOrDefaultAsync(f => f.Id == form.Id && f.ApplicationUserId == userId);

            if (feedback == null)
            {
                return RedirectToAction("Index", new { carId = feedback!.CarId });
            }

            feedback.Comment = form.Comment;
            feedback.Rating = form.Rating;
            await _context.SaveChangesAsync();

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

            var feedback = await _context.Feedbacks
                .FirstOrDefaultAsync(f => f.Id == id && f.ApplicationUserId == userId);

            if (feedback == null)
            {
                return RedirectToAction("Index", new { carId = feedback!.CarId });
            }

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { carId = feedback.CarId });
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
