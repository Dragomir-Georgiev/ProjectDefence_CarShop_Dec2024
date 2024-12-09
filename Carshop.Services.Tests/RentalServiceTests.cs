using CarShop.Data.Models;
using CarShop.Data.Repository.Interfaces;
using CarShop.Services.Data;
using CarShop.Services.Mapping;
using CarShop.Web.ViewModels;
using CarShop.Web.ViewModels.Rental;
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
    public class RentalServiceTests
    {
        private Mock<IRepository<Car, Guid>> _mockCarRepository;
        private Mock<IRepository<Rental, Guid>> _mockRentalRepository;
        private Mock<IRepository<ApplicationUserRental, object>> _mockUserRentalRepository;
        private Mock<IRepository<DamageReport, Guid>> _mockDamageReportRepository;
        private RentalService _rentalService;


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);
        }

        [SetUp]
        public void SetUp()
        {
            _mockCarRepository = new Mock<IRepository<Car, Guid>>();
            _mockRentalRepository = new Mock<IRepository<Rental, Guid>>();
            _mockUserRentalRepository = new Mock<IRepository<ApplicationUserRental, object>>();
            _mockDamageReportRepository = new Mock<IRepository<DamageReport, Guid>>();

            _rentalService = new RentalService(
                _mockCarRepository.Object,
                _mockRentalRepository.Object,
                _mockUserRentalRepository.Object,
                _mockDamageReportRepository.Object);
        }

        [Test]
        public async Task GetRentalIndexAsyncShouldReturnViewModelIfTheCarExists()
        {
            var carId = Guid.Parse("FE72465C-6DA7-438D-8655-EB8E481D2D4B");
            var car = new Car { Id = carId, Make = "Toyota", Model = "Camry" };

            _mockCarRepository
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Car, bool>>>()))
                .ReturnsAsync(car);

            var result = await _rentalService.GetRentalIndexAsync(carId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.CarId.ToLower(), Is.EqualTo(carId.ToString().ToLower()));
            Assert.That(result.Make, Is.EqualTo("Toyota"));
            Assert.That(result.Model, Is.EqualTo("Camry"));
        }

        [Test]
        public async Task GetRentalIndexAsyncShouldReturnNullIfTheCarDoesNotExist()
        {
            var carId = Guid.Parse("FE72465C-6DA7-438D-8655-EB8E481D2D4B");

#pragma warning disable CS8620
            _mockCarRepository
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Car, bool>>>()))
                .ReturnsAsync((Car?)null);
#pragma warning restore CS8620

            var result = await _rentalService.GetRentalIndexAsync(carId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetConfirmRentalIndexAsyncShouldReturnViewModelIfTheCarExists()
        {
            var carId = Guid.Parse("FE72465C-6DA7-438D-8655-EB8E481D2D4B");
            var car = new Car { Id = carId, Make = "Toyota", Model = "Camry", PricePerDay = 50, CarImage = null };

            _mockCarRepository
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Car, bool>>>()))
                .ReturnsAsync(car);

            var rentalViewModel = new IndexRentalViewModel
            {
                CarId = carId.ToString(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3)
            };

            var result = await _rentalService.GetConfirmRentalIndexAsync(rentalViewModel, carId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.CarId.ToLower(), Is.EqualTo(carId.ToString().ToLower()));
            Assert.That(result.TotalCost, Is.EqualTo(200));
            Assert.That(result.CarImage, Is.EqualTo("/images/no-car-img.jpg"));
        }

        [Test]
        public async Task GetConfirmRentalIndexAsyncShouldReturnNullIfTheCarDoesNotExists()
        {
            var carId = Guid.Parse("FE72465C-6DA7-438D-8655-EB8E481D2D4B");

#pragma warning disable CS8620
            _mockCarRepository
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Car, bool>>>()))
                .ReturnsAsync((Car?)null);
#pragma warning restore CS8620

            var rentalViewModel = new IndexRentalViewModel
            {
                CarId = carId.ToString(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3)
            };

            var result = await _rentalService.GetConfirmRentalIndexAsync(rentalViewModel, carId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task AddRentalAsyncShouldAddRentalIfTheCarExists()
        {
            var carId = Guid.Parse("584EE3F0-0C77-4927-9958-6FCC2BC7778D");
            var userId = Guid.Parse("7095BF7D-0B98-4036-8984-78140F58B53D");
            var rental = (Rental?)null;

            var car = new Car { Id = carId, IsAvailable = true };

            _mockCarRepository
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Car, bool>>>()))
                .ReturnsAsync(car);

            var rentalViewModel = new ConfirmRentalViewModel
            {
                CarId = carId.ToString(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                TotalCost = 150
            };

            _mockRentalRepository
                .Setup(repo => repo.AddAsync(It.IsAny<Rental>()))
                .Callback<Rental>(r => rental = r);

            var result = await _rentalService.AddRentalAsync(rentalViewModel, userId, carId);

            Assert.That(result, Is.True);
            Assert.That(car.IsAvailable, Is.False);
            Assert.That(rental, Is.Not.Null);
            Assert.That(rental.CarId, Is.EqualTo(carId));
        }

        [Test]
        public async Task AddRentalAsyncShouldReturnFalseIfTheCarDoesNotExists()
        {
            var carId = Guid.Parse("584EE3F0-0C77-4927-9958-6FCC2BC7778D");
            var userId = Guid.Parse("7095BF7D-0B98-4036-8984-78140F58B53D");

#pragma warning disable CS8620
            _mockCarRepository
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Car, bool>>>()))
                .ReturnsAsync((Car?)null);
#pragma warning restore CS8620
            var rentalViewModel = new ConfirmRentalViewModel
            {
                CarId = carId.ToString(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                TotalCost = 150
            };

            var result = await _rentalService.AddRentalAsync(rentalViewModel, userId, carId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetRentedCarsAsyncShouldReturnRentedCarsIfTheUserHasRentals()
        {
            var userId = Guid.Parse("584EE3F0-0C77-4927-9958-6FCC2BC7778D");
            var rentalId = Guid.Parse("7095BF7D-0B98-4036-8984-78140F58B53D");

            var car = new Car { Id = Guid.Parse("10EF2712-3B08-422E-934C-F647AA9499A4"), Make = "Toyota", Model = "Camry", CarImage = null };

            var rentals = new List<Rental>
            {
                new Rental { Id = rentalId, Car = car, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(3), TotalCost = 150, ApplicationUserRentals = new List<ApplicationUserRental> { new ApplicationUserRental { ApplicationUserId = userId } } }
            }
            .BuildMock();

            _mockRentalRepository.Setup(repo => repo.GetAllAttached())
                .Returns(rentals);

            var result = await _rentalService.GetRentedCarsAsync(userId);

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First().RentalId, Is.EqualTo(rentalId));
            Assert.That(result.First().Make, Is.EqualTo(car.Make));
        }

        [Test]
        public async Task GetRentedCarsAsyncShouldReturnEmptyRentedCarsIfTheUserDoesNotHaveRentals()
        {
            var userId = Guid.Parse("584EE3F0-0C77-4927-9958-6FCC2BC7778D");

            var emptyRentals = new List<Rental>().BuildMock();

            _mockRentalRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(emptyRentals);

            var result = await _rentalService.GetRentedCarsAsync(userId);

            Assert.That(result, Is.Empty);
        }
    }
}
