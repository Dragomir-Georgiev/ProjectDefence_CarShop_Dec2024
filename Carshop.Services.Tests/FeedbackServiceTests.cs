using CarShop.Data.Models;
using CarShop.Data.Repository.Interfaces;
using CarShop.Services.Data;
using CarShop.Services.Mapping;
using CarShop.Web.ViewModels;
using CarShop.Web.ViewModels.Feedback;
using MockQueryable;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Carshop.Services.Tests
{
    [TestFixture]
    public class FeedbackServiceTests
    {
        private Mock<IRepository<Feedback, Guid>> _mockFeedbackRepository;
        private Mock<IRepository<Car, Guid>> _mockCarRepository;
        private FeedbackService _feedbackService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);
        }

        [SetUp]
        public void SetUp()
        {
            _mockFeedbackRepository = new Mock<IRepository<Feedback, Guid>>();
            _mockCarRepository = new Mock<IRepository<Car, Guid>>();
            _feedbackService = new FeedbackService(_mockFeedbackRepository.Object, _mockCarRepository.Object);
        }

        [Test]
        public async Task GetFeedbacksByCarIdAsyncShouldReturnTheFeedbacksIfTheCarExists()
        {
            var carId = Guid.Parse("160322C4-5489-4C9C-8910-30638153F902");
            var userId = Guid.Parse("44C9BE1D-E92D-49DB-BC8E-E2DF7819D444");

            var car = new Car { Id = carId, Make = "Toyota", Model = "Camry" };
            _mockCarRepository
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Car, bool>>>()))
                .ReturnsAsync(car);


            var feedbacks = new List<Feedback>
            {
                new Feedback() { Id = Guid.Parse("0E74BB74-84B7-4732-9617-D3A41B07CEF6"), Comment = "Great car!", FeedbackDate = DateTime.Now, Rating = 5, CarId = carId, ApplicationUser = new ApplicationUser { Id = userId, UserName = "JohnDoe" } }
            }
            .BuildMock();

            _mockFeedbackRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(feedbacks);

            var result = await _feedbackService.GetFeedbacksByCarIdAsync(carId, userId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.CarMakeModel, Is.EqualTo("Toyota Camry"));
            Assert.That(result.Feedbacks.Count, Is.EqualTo(1));
            Assert.That(result.Feedbacks.First().Comment, Is.EqualTo("Great car!"));
        }

        [Test]
        public async Task GetFeedbacksByCarIdAsyncShouldReturnNullIfTheCarDoesNotExist()
        {
            var carId = Guid.Parse("160322C4-5489-4C9C-8910-30638153F902");
            var userId = Guid.Parse("44C9BE1D-E92D-49DB-BC8E-E2DF7819D444");

#pragma warning disable CS8620
            _mockCarRepository
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Car, bool>>>()))
                .ReturnsAsync((Car?)null);
#pragma warning restore CS8620

            var result = await _feedbackService.GetFeedbacksByCarIdAsync(carId, userId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task AddFeedbackAsyncShouldAddTheFeedbackWhenTheCarExists()
        {
            var carId = Guid.Parse("160322C4-5489-4C9C-8910-30638153F902");
            var userId = Guid.Parse("44C9BE1D-E92D-49DB-BC8E-E2DF7819D444");

            var car = new Car { Id = carId };
            _mockCarRepository
                .Setup(repo => repo.GetByIdAsync(carId))
                .ReturnsAsync(car);

            var feedbackId = Guid.Parse("862D0064-04AE-469A-87B9-54D627FB3858");
            var feedbackModel = new AddFeedbackViewModel
            {
                Id = feedbackId,
                CarId = carId,
                Comment = "Great car!",
                Rating = 5
            };

            Feedback? capturedFeedback = null;
            _mockFeedbackRepository
                .Setup(repo => repo.AddAsync(It.IsAny<Feedback>()))
                .Callback<Feedback>(feedback =>
                {
                    feedback.Id = feedbackId;
                    capturedFeedback = feedback;
                });

            var result = await _feedbackService.AddFeedbackAsync(feedbackModel, userId);

            Assert.That(result, Is.True);
            Assert.That(capturedFeedback, Is.Not.Null);
            Assert.That(capturedFeedback.Id.ToString().ToLower(), Is.EqualTo(feedbackId.ToString().ToLower()));
            Assert.That(capturedFeedback.Comment, Is.EqualTo("Great car!"));
            Assert.That(capturedFeedback.Rating, Is.EqualTo(5));
            Assert.That(capturedFeedback.CarId, Is.EqualTo(carId));
            Assert.That(capturedFeedback.ApplicationUserId, Is.EqualTo(userId));
        }

        [Test]
        public async Task AddFeedbackAsyncShouldReturnFalseIfTheCarDoesNotExist()
        {
            var carId = Guid.Parse("160322C4-5489-4C9C-8910-30638153F902");
            var userId = Guid.Parse("44C9BE1D-E92D-49DB-BC8E-E2DF7819D444");

#pragma warning disable CS8620
            _mockCarRepository
                .Setup(repo => repo.GetByIdAsync(carId))
                .ReturnsAsync((Car?)null);
#pragma warning restore CS8620

            var feedbackModel = new AddFeedbackViewModel
            {
                CarId = carId,
                Comment = "Great car!",
                Rating = 5
            };

            var result = await _feedbackService.AddFeedbackAsync(feedbackModel, userId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetFeedbackForEditAsyncShouldReturnTheFeedbackIfTheFeedbackExistsAndIsOwnedByTheUser()
        {
            var feedbackId = Guid.Parse("160322C4-5489-4C9C-8910-30638153F902");
            var userId = Guid.Parse("44C9BE1D-E92D-49DB-BC8E-E2DF7819D444");

            var feedback = new Feedback
            {
                Id = feedbackId,
                Comment = "Great car!",
                Rating = 5,
                ApplicationUserId = userId
            };

            _mockFeedbackRepository
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Feedback, bool>>>()))
                .ReturnsAsync(feedback);

            var result = await _feedbackService.GetFeedbackForEditAsync(feedbackId, userId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id.ToString().ToLower(), Is.EqualTo(feedbackId.ToString().ToLower()));
        }

        [Test]
        public async Task GetFeedbackForEditAsyncShouldReturnNullIfTheFeedbackIsNotOwnedByTheUser()
        {
            var feedbackId = Guid.Parse("160322C4-5489-4C9C-8910-30638153F902");
            var userId = Guid.Parse("44C9BE1D-E92D-49DB-BC8E-E2DF7819D444");

            var feedback = new Feedback
            {
                Id = feedbackId,
                Comment = "Great car!",
                Rating = 5,
                ApplicationUserId = Guid.NewGuid()
            };

            _mockFeedbackRepository
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Feedback, bool>>>()))
                .ReturnsAsync(feedback);

            var result = await _feedbackService.GetFeedbackForEditAsync(feedbackId, userId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetFeedbackForEditAsyncShouldReturnNullIfTheFeedbackDoesNotExist()
        {
            var feedbackId = Guid.Parse("160322C4-5489-4C9C-8910-30638153F902");
            var userId = Guid.Parse("44C9BE1D-E92D-49DB-BC8E-E2DF7819D444");

#pragma warning disable CS8620
            _mockFeedbackRepository
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Feedback, bool>>>()))
                .ReturnsAsync((Feedback?)null);
#pragma warning restore CS8620

            var result = await _feedbackService.GetFeedbackForEditAsync(feedbackId, userId);

            Assert.That(result, Is.Null);
        }
    }
}
