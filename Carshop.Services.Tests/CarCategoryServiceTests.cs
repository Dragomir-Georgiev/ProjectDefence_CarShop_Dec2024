using CarShop.Data.Models;
using CarShop.Data.Repository.Interfaces;
using CarShop.Services.Data;
using CarShop.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moq;
using MockQueryable;

namespace Carshop.Services.Tests
{

    [TestFixture]
    public class CarCategoryServiceTests
    {
        private Mock<IRepository<CarCategory, Guid>> _mockCategoryRepository;
        private ICarCategoryService _carCategoryService;

        [SetUp]
        public void SetUp()
        {
            _mockCategoryRepository = new Mock<IRepository<CarCategory, Guid>>();
            _carCategoryService = new CarCategoryService(_mockCategoryRepository.Object);
        }

        [Test]
        public async Task GetCarCategoriesAsyncShouldReturnAllCarCategories()
        {
            IQueryable<CarCategory> categories = new List<CarCategory>()
            {
                new CarCategory() { Id = Guid.Parse("5E5B45B5-6BCE-4E8C-A05A-EB6D5540F9CE"), CategoryName = "SUV" },
                new CarCategory() { Id = Guid.Parse("DF2CDC1F-46C7-428B-A54B-E03EB0E33A7F"), CategoryName = "Sedan" },
                new CarCategory() { Id = Guid.Parse("A69FE7AC-6AD4-403F-BA76-EEFBC3A691C6"), CategoryName = "Pickup truck" }
            }
            .BuildMock();

            _mockCategoryRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(categories);

            var result = await _carCategoryService.GetCarCategoriesAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(categories.Count()));
            int i = 0;
            foreach (SelectListItem category in result)
            {
                Assert.That(category.Value, Is.EqualTo(categories.ToList()[i++].Id.ToString()));
            }
        }

        [Test]
        public async Task GetCarCategoriesAsyncShouldReturnEmptyListIfThereAreNoCarCategories()
        {
            IQueryable<CarCategory> emptyCategories = new List<CarCategory>()
                .BuildMock();

            _mockCategoryRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(emptyCategories);

            var result = await _carCategoryService.GetCarCategoriesAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}