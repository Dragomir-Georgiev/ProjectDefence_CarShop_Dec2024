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

        [SetUp]
        public void SetUp()
        {
            _mockCategoryRepository = new Mock<IRepository<CarCategory, Guid>>();
        }

        [Test]
        public async Task GetCarCategoriesAsyncShouldReturnAllCarCategories()
        {
            IQueryable<CarCategory> categories = new List<CarCategory>()
            {
                new CarCategory() { Id = Guid.Parse("1D641640-809D-42B1-8A00-18E6CB90A1A8"), CategoryName = "SUV" },
                new CarCategory() { Id = Guid.Parse("45270723-036F-442A-BE03-C43561589F13"), CategoryName = "Sedan" },
                new CarCategory() { Id = Guid.Parse("3030A872-DA71-4E9F-9B61-DA6CA8EA0190"), CategoryName = "Truck" }
            }
            .AsQueryable()
            .BuildMock();

            _mockCategoryRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(categories);

            ICarCategoryService carCategoryService = new CarCategoryService(_mockCategoryRepository.Object);

            var result = await carCategoryService.GetCarCategoriesAsync();

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
                .AsQueryable()
                .BuildMock();

            _mockCategoryRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(emptyCategories);

            ICarCategoryService _carCategoryService = new CarCategoryService(_mockCategoryRepository.Object);

            var result = await _carCategoryService.GetCarCategoriesAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}