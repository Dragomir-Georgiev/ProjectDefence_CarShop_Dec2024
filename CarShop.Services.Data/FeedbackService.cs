using CarShop.Data.Models;
using CarShop.Data.Repository.Interfaces;
using CarShop.Services.Data.Interfaces;
using CarShop.Services.Mapping;
using CarShop.Web.ViewModels.Feedback;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Data
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IRepository<Feedback, Guid> _feedbackRepository;
        private readonly IRepository<Car, Guid> _carRepository;

        public FeedbackService(IRepository<Feedback, Guid> feedbackRepository, 
            IRepository<Car, Guid> carRepository)
        {
            _feedbackRepository = feedbackRepository;
            _carRepository = carRepository;
        }
        public async Task<IndexFeedbackViewModel?> GetFeedbacksByCarIdAsync(Guid carId, Guid userId)
        {
            var validCar = await _carRepository.FirstOrDefaultAsync(c => c.Id == carId);
            if (validCar == null)
            {
                return null;
            }

            List<FeedbackViewModel> feedbacks = await _feedbackRepository
                .GetAllAttached()
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
            return viewModel;
        }
        public async Task<bool> AddFeedbackAsync(AddFeedbackViewModel viewModel, Guid userId)
        {
            var car = await _carRepository.GetByIdAsync(viewModel.CarId);
            if (car == null)
            {
                return false;
            }

            var feedback = new Feedback()
            {
                Comment = viewModel.Comment,
                FeedbackDate = DateTime.Now,
                Rating = viewModel.Rating,
                CarId = viewModel.CarId,
                ApplicationUserId = userId,
            };

            await _feedbackRepository.AddAsync(feedback);
            await _feedbackRepository.SaveChangesAsync();

            return true;
        }
        public async Task<AddFeedbackViewModel?> GetFeedbackForEditAsync(Guid feedbackId, Guid userId)
        {
            var feedback = await _feedbackRepository
                .FirstOrDefaultAsync(f => f.Id == feedbackId);

            if (feedback == null || feedback.ApplicationUserId != userId)
            {
                return null;
            }

            var viewModel = new AddFeedbackViewModel
            {
                Id = feedback.Id,
                CarId = feedback.CarId,
                Comment = feedback.Comment,
                Rating = feedback.Rating
            };

            return viewModel;
        }

        public async Task<bool> EditFeedbackAsync(AddFeedbackViewModel form, Guid userId)
        {
            var feedback = await _feedbackRepository
                .FirstOrDefaultAsync(f => f.Id == form.Id && f.ApplicationUserId == userId);

            if (feedback == null)
            {
                return false;
            }

            feedback.Comment = form.Comment;
            feedback.Rating = form.Rating;

            await _feedbackRepository.SaveChangesAsync();
            return true;
        }



        public async Task<bool> RemoveFeedbackAsync(Guid feedbackId, Guid userId)
        {
            var feedback = await _feedbackRepository
                .FirstOrDefaultAsync(f => f.Id == feedbackId && f.ApplicationUserId == userId);

            if (feedback == null)
            {
                return false;
            }

            _feedbackRepository.Delete(feedback);
            await _feedbackRepository.SaveChangesAsync();
            return true;
        }
    }
}
