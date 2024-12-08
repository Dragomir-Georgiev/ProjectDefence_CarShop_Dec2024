using CarShop.Data.Repository.Interfaces;
using CarShop.Services.Data.Interfaces;
using CarShop.Services.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Models;
using CarShop.Web.ViewModels.Car;
using MockQueryable;
using CarShop.Data.Models.Enums;
using CarShop.Services.Mapping;
using CarShop.Web.ViewModels;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Carshop.Services.Tests
{
    [TestFixture]
    public class CarServiceTests
    {
        private Mock<IRepository<Car, Guid>> _mockCarRepository;
        private Mock<ICarCategoryService> _mockCarCategoryService;
        private ICarService _carService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);
        }

        [SetUp]
        public void SetUp()
        {
            _mockCarRepository = new Mock<IRepository<Car, Guid>>();
            _mockCarCategoryService = new Mock<ICarCategoryService>();
            _carService = new CarService(_mockCarRepository.Object, _mockCarCategoryService.Object);
        }

        [Test]
        public async Task IndexGetAllAsyncShouldReturnAllCarsWhenNoFiltersAreApplied()
        {
            IQueryable<Car> cars = new List<Car>
            {
                new Car() { Id = Guid.Parse("4590F15D-634B-4A10-9F69-32A88931922F"), Make = "Porsche", Model = "911", ProductionYear = 2024, FuelConsumption = 13.8, TankVolume = 64, MaximumSpeed = 311, CarImage = "https://r44performance.com/cdn/shop/articles/R44Performance-Porsche-911-GT3RS.jpg?v=1710775245&width=1500", DoorsCount = 2,SeatingCapacity = 2, TransmissionType = TransmissionType.Automatic, PricePerDay = 1135.46m, IsAvailable = true, IsDeleted = false, CarCategoryId = Guid.Parse("264E1F65-36E4-44FB-9605-64BEC9B9ED7A") },
                new Car() { Id = Guid.Parse("E3EA8915-979C-478F-B597-4B50E5F31CFD"), Make = "McLaren", Model = "750S Spider", ProductionYear = 2023, FuelConsumption = 12.2, TankVolume = 72, MaximumSpeed = 332, CarImage = "https://images.pistonheads.com/nimg/48142/blobid0.jpg", DoorsCount = 2, SeatingCapacity = 2, TransmissionType = TransmissionType.Automatic, PricePerDay = 1797.90m, IsAvailable = true, IsDeleted = false, CarCategoryId = Guid.Parse("9C8E3EAD-80A2-45C6-AFBA-91248BAEBEF3") },
                new Car() { Id = Guid.Parse("EEA3A59B-1D08-47D5-82F5-863384B9DF71"), Make = "RAM", Model = "1500", ProductionYear = 2024, FuelConsumption = 15.7, TankVolume = 125, MaximumSpeed = 190, CarImage = "https://www.ramtrucks.com/content/dam/fca-brands/na/ramtrucks/en_us/2025/ram-1500/gallery/desktop/my25-ram-1500-gallery-open-1-d.jpg", DoorsCount = 4, SeatingCapacity = 6, TransmissionType = TransmissionType.Automatic, PricePerDay = 317.28m, IsAvailable = true, IsDeleted = false, CarCategoryId = Guid.Parse("A69FE7AC-6AD4-403F-BA76-EEFBC3A691C6") }
            }
            .BuildMock();

            _mockCarRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(cars);

            IEnumerable<AllCarsIndexViewModel> result = await _carService
                .IndexGetAllAsync(new AllCarSearchFilterViewModel());

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(cars.Count()));

            int i = 0;
            foreach (AllCarsIndexViewModel car in result)
            {
                Assert.That(car.Id, Is.EqualTo(cars.ToList()[i++].Id.ToString()));
            }
        }

        [Test]
        [TestCase("Por")]
        [TestCase("por")]
        public async Task IndexGetAllAsyncShouldReturnOnlyTheSpecifiqueCarsThatMatchTheSearchQuery(string searchQuery)
        {
            int expectedCarCount = 1;
            string expectedCarId = "4590F15D-634B-4A10-9F69-32A88931922F";

            IQueryable<Car> cars = new List<Car>
            {
                new Car() { Id = Guid.Parse("4590F15D-634B-4A10-9F69-32A88931922F"), Make = "Porsche", Model = "911", ProductionYear = 2024, FuelConsumption = 13.8, TankVolume = 64, MaximumSpeed = 311, CarImage = "https://r44performance.com/cdn/shop/articles/R44Performance-Porsche-911-GT3RS.jpg?v=1710775245&width=1500", DoorsCount = 2,SeatingCapacity = 2, TransmissionType = TransmissionType.Automatic, PricePerDay = 1135.46m, IsAvailable = true, IsDeleted = false, CarCategoryId = Guid.Parse("264E1F65-36E4-44FB-9605-64BEC9B9ED7A") },
                new Car() { Id = Guid.Parse("E3EA8915-979C-478F-B597-4B50E5F31CFD"), Make = "McLaren", Model = "750S Spider", ProductionYear = 2023, FuelConsumption = 12.2, TankVolume = 72, MaximumSpeed = 332, CarImage = "https://images.pistonheads.com/nimg/48142/blobid0.jpg", DoorsCount = 2, SeatingCapacity = 2, TransmissionType = TransmissionType.Automatic, PricePerDay = 1797.90m, IsAvailable = true, IsDeleted = false, CarCategoryId = Guid.Parse("9C8E3EAD-80A2-45C6-AFBA-91248BAEBEF3") },
                new Car() { Id = Guid.Parse("EEA3A59B-1D08-47D5-82F5-863384B9DF71"), Make = "RAM", Model = "1500", ProductionYear = 2024, FuelConsumption = 15.7, TankVolume = 125, MaximumSpeed = 190, CarImage = "https://www.ramtrucks.com/content/dam/fca-brands/na/ramtrucks/en_us/2025/ram-1500/gallery/desktop/my25-ram-1500-gallery-open-1-d.jpg", DoorsCount = 4, SeatingCapacity = 6, TransmissionType = TransmissionType.Automatic, PricePerDay = 317.28m, IsAvailable = true, IsDeleted = false, CarCategoryId = Guid.Parse("A69FE7AC-6AD4-403F-BA76-EEFBC3A691C6") }
            }
            .BuildMock();

            this._mockCarRepository
                .Setup(r => r.GetAllAttached())
                .Returns(cars);
            
            IEnumerable<AllCarsIndexViewModel> result = await _carService
                .IndexGetAllAsync(new AllCarSearchFilterViewModel()
                {
                    SearchQuery = searchQuery,
                    EntitiesPerPage = 1,
                    CurrentPage = 1
                });
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(expectedCarCount));
            Assert.That(result.First().Id.ToLower(), Is.EqualTo(expectedCarId.ToLower()));
        }

        [Test]
        public async Task IndexGetAllAsyncShouldReturnAllTheCarsThatHaveAHigherPriceThanThePriceFilter()
        {
            int expectedCarCount = 1;
            string expectedCarId = "E3EA8915-979C-478F-B597-4B50E5F31CFD";

            IQueryable<Car> cars = new List<Car>
            {
                new Car() { Id = Guid.Parse("4590F15D-634B-4A10-9F69-32A88931922F"), Make = "Porsche", Model = "911", ProductionYear = 2024, FuelConsumption = 13.8, TankVolume = 64, MaximumSpeed = 311, CarImage = "https://r44performance.com/cdn/shop/articles/R44Performance-Porsche-911-GT3RS.jpg?v=1710775245&width=1500", DoorsCount = 2,SeatingCapacity = 2, TransmissionType = TransmissionType.Automatic, PricePerDay = 1135.46m, IsAvailable = true, IsDeleted = false, CarCategoryId = Guid.Parse("264E1F65-36E4-44FB-9605-64BEC9B9ED7A") },
                new Car() { Id = Guid.Parse("E3EA8915-979C-478F-B597-4B50E5F31CFD"), Make = "McLaren", Model = "750S Spider", ProductionYear = 2023, FuelConsumption = 12.2, TankVolume = 72, MaximumSpeed = 332, CarImage = "https://images.pistonheads.com/nimg/48142/blobid0.jpg", DoorsCount = 2, SeatingCapacity = 2, TransmissionType = TransmissionType.Automatic, PricePerDay = 1797.90m, IsAvailable = true, IsDeleted = false, CarCategoryId = Guid.Parse("9C8E3EAD-80A2-45C6-AFBA-91248BAEBEF3") },
                new Car() { Id = Guid.Parse("EEA3A59B-1D08-47D5-82F5-863384B9DF71"), Make = "RAM", Model = "1500", ProductionYear = 2024, FuelConsumption = 15.7, TankVolume = 125, MaximumSpeed = 190, CarImage = "https://www.ramtrucks.com/content/dam/fca-brands/na/ramtrucks/en_us/2025/ram-1500/gallery/desktop/my25-ram-1500-gallery-open-1-d.jpg", DoorsCount = 4, SeatingCapacity = 6, TransmissionType = TransmissionType.Automatic, PricePerDay = 317.28m, IsAvailable = true, IsDeleted = false, CarCategoryId = Guid.Parse("A69FE7AC-6AD4-403F-BA76-EEFBC3A691C6") }
            }
            .BuildMock();

            this._mockCarRepository
                .Setup(r => r.GetAllAttached())
                .Returns(cars);

            IEnumerable<AllCarsIndexViewModel> result = await _carService
                .IndexGetAllAsync(new AllCarSearchFilterViewModel()
                {
                    PriceFilter = 1500m,
                    EntitiesPerPage = 1,
                    CurrentPage = 1
                });

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(expectedCarCount));
            Assert.That(result.First().Id.ToLower(), Is.EqualTo(expectedCarId.ToLower()));
        }

        [Test]
        public async Task IndexGetAllAsyncShouldReturnNoCarsIfNoneOfThemMatchTheFilters()
        {
            int expectedCarCount = 0;

            IQueryable<Car> cars = new List<Car>
            {
                new Car() { Id = Guid.Parse("4590F15D-634B-4A10-9F69-32A88931922F"), Make = "Porsche", Model = "911", ProductionYear = 2024, FuelConsumption = 13.8, TankVolume = 64, MaximumSpeed = 311, CarImage = "https://r44performance.com/cdn/shop/articles/R44Performance-Porsche-911-GT3RS.jpg?v=1710775245&width=1500", DoorsCount = 2,SeatingCapacity = 2, TransmissionType = TransmissionType.Automatic, PricePerDay = 1135.46m, IsAvailable = true, IsDeleted = false, CarCategoryId = Guid.Parse("264E1F65-36E4-44FB-9605-64BEC9B9ED7A") },
                new Car() { Id = Guid.Parse("E3EA8915-979C-478F-B597-4B50E5F31CFD"), Make = "McLaren", Model = "750S Spider", ProductionYear = 2023, FuelConsumption = 12.2, TankVolume = 72, MaximumSpeed = 332, CarImage = "https://images.pistonheads.com/nimg/48142/blobid0.jpg", DoorsCount = 2, SeatingCapacity = 2, TransmissionType = TransmissionType.Automatic, PricePerDay = 1797.90m, IsAvailable = true, IsDeleted = false, CarCategoryId = Guid.Parse("9C8E3EAD-80A2-45C6-AFBA-91248BAEBEF3") },
                new Car() { Id = Guid.Parse("EEA3A59B-1D08-47D5-82F5-863384B9DF71"), Make = "RAM", Model = "1500", ProductionYear = 2024, FuelConsumption = 15.7, TankVolume = 125, MaximumSpeed = 190, CarImage = "https://www.ramtrucks.com/content/dam/fca-brands/na/ramtrucks/en_us/2025/ram-1500/gallery/desktop/my25-ram-1500-gallery-open-1-d.jpg", DoorsCount = 4, SeatingCapacity = 6, TransmissionType = TransmissionType.Automatic, PricePerDay = 317.28m, IsAvailable = true, IsDeleted = false, CarCategoryId = Guid.Parse("A69FE7AC-6AD4-403F-BA76-EEFBC3A691C6") }
            }
            .BuildMock();

            this._mockCarRepository
                .Setup(r => r.GetAllAttached())
                .Returns(cars);

            IEnumerable<AllCarsIndexViewModel> result = await _carService
                .IndexGetAllAsync(new AllCarSearchFilterViewModel()
                {
                    SearchQuery = "Transformers"
                });

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(expectedCarCount));
        }

        [Test]
        public async Task AddCarAsyncShouldAddTheCarToTheRepository()
        {
            string expectedCarMake = "Porsche";

            AddCarViewModel carModel = new AddCarViewModel() { Make = "Porsche", Model = "911", ProductionYear = 2024, FuelConsumption = 13.8, TankVolume = 64, MaximumSpeed = 311, CarImage = "https://r44performance.com/cdn/shop/articles/R44Performance-Porsche-911-GT3RS.jpg?v=1710775245&width=1500", DoorsCount = 2, SeatingCapacity = 2, TransmissionType = TransmissionType.Automatic, PricePerDay = 1135.46m, CarCategoryId = Guid.Parse("264E1F65-36E4-44FB-9605-64BEC9B9ED7A") };

            Car? addedCar = null;

            this._mockCarRepository
                .Setup(repo => repo.AddAsync(It.IsAny<Car>()))
                .Callback<Car>(car => addedCar = car);

            await _carService.AddCarAsync(carModel);

            Assert.That(addedCar, Is.Not.Null);
            Assert.That(addedCar.Make.ToLower(), Is.EqualTo(expectedCarMake.ToLower()));
        }

        [Test]
        public async Task GetCarDetailsByIdAsyncShouldReturnTheCarDetails()
        {
            Guid expectedCarId = Guid.Parse("1AB71A17-A56F-49A2-A5D3-E8C9C0BFC3F4");
            var carCategory = new CarCategory { Id = Guid.NewGuid(), CategoryName = "SUV" };
            var damageReports = new List<DamageReport>
            {
                new DamageReport { Id = Guid.Parse("34D12FB5-990B-43F8-A02B-E79A0AF5566A"), Description = "Scratch on bumper", CarId = expectedCarId }
            };
            var feedbacks = new List<Feedback>
            {
                new Feedback { Id = Guid.Parse("1A5414A6-A27A-42CF-8971-07B4E22F4317"), Comment = "Great car! It was amazing",  CarId = expectedCarId }
            };

            IQueryable<Car> cars = new List<Car>
            {
                new Car() { Id = expectedCarId, Make = "Porsche", Model = "911", ProductionYear = 2024, FuelConsumption = 13.8, TankVolume = 64, MaximumSpeed = 311, CarImage = "https://r44performance.com/cdn/shop/articles/R44Performance-Porsche-911-GT3RS.jpg?v=1710775245&width=1500", DoorsCount = 2,SeatingCapacity = 2, TransmissionType = TransmissionType.Automatic, PricePerDay = 1135.46m, IsAvailable = true, IsDeleted = false, CarCategoryId = Guid.Parse("264E1F65-36E4-44FB-9605-64BEC9B9ED7A"), CarCategory = carCategory, DamageReports = damageReports, Feedbacks = feedbacks, }
            }
            .BuildMock();

            _mockCarRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(cars);

            var result = await _carService.GetCarDetailsByIdAsync(expectedCarId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id.ToString().ToLower(), Is.EqualTo(expectedCarId.ToString().ToLower()));
        }

        [Test]
        public async Task UpdateCarAsyncShouldUpdateTheCarDetails()
        {
            var carId = Guid.Parse("A11F9519-D111-4E63-9D3F-C78956B4C569");
            var car = new Car { Id = carId, Make = "Audi", IsDeleted = false };
            var editModel = new EditCarViewModel
            {
                Make = "Audi Updated",
                Model = "A6"
            };

            _mockCarRepository
                .Setup(repo => repo.GetByIdAsync(carId))
                .ReturnsAsync(car);

            _mockCarRepository
                .Setup(repo => repo.Update(car))
                .Returns(true);

            var result = await _carService.UpdateCarAsync(carId, editModel);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task UpdateCarAsyncShouldReturnFalseIfTheCarIsNotFound()
        {
            var carId = Guid.Parse("A11F9519-D111-4E63-9D3F-C78956B4C569");
            var editModel = new EditCarViewModel { Make = "Updated Make" };

#pragma warning disable CS8620
            _mockCarRepository
                .Setup(repo => repo.GetByIdAsync(carId))
                .ReturnsAsync((Car?)null);
#pragma warning restore CS8620

            var result = await _carService.UpdateCarAsync(carId, editModel);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task UpdateCarAsyncShouldReturnFalseIfTheCarIsDeleted()
        {
            var carId = Guid.Parse("A11F9519-D111-4E63-9D3F-C78956B4C569");
            var car = new Car { Id = carId, IsDeleted = true };
            var editModel = new EditCarViewModel { Make = "Updated Make" };

            _mockCarRepository
                .Setup(repo => repo.GetByIdAsync(carId))
                .ReturnsAsync(car);

            var result = await _carService.UpdateCarAsync(carId, editModel);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task SoftDeleteCarAsyncShouldMarkTheCarAsDeleted()
        {
            var carId = Guid.Parse("A11F9519-D111-4E63-9D3F-C78956B4C569");

            var cars = new List<Car> 
            {
                new Car 
                { 
                    Id = carId, 
                    IsDeleted = false 
                }
            }
            .BuildMock();

            _mockCarRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(cars);

            await _carService.SoftDeleteCarAsync(carId);

            Assert.That(cars.First().IsDeleted, Is.True);
        }

        [Test]
        public async Task GetDeleteCarModelAsyncShouldReturnDeleteCarViewModelIfTheCarExists()
        {
            var carId = Guid.Parse("A11F9519-D111-4E63-9D3F-C78956B4C569");
            var carCategory = new CarCategory { Id = Guid.Parse("8E366AF6-2E36-44E5-BC98-E92508A2DD3A"), CategoryName = "SUV" };

            var cars = new List<Car>
            {
                new Car
                {
                    Id = carId,
                    Make = "Tesla",
                    Model = "Model Y",
                    CarCategory = carCategory,
                    IsDeleted = false
                }
            }
            .BuildMock();

            _mockCarRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(cars);

            var result = await _carService.GetDeleteCarModelAsync(carId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(carId.ToString()));
            Assert.That(result.Make, Is.EqualTo("Tesla"));
            Assert.That(result.Model, Is.EqualTo("Model Y"));
            Assert.That(result.CategoryName, Is.EqualTo("SUV"));
        }

        [Test]
        public async Task GetDeleteCarModelAsyncShouldReturnNullIfTheCarDoesNotExist()
        {
            var carId = Guid.Parse("A11F9519-D111-4E63-9D3F-C78956B4C569");

            var cars = new List<Car>()
                .BuildMock();

            _mockCarRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(cars);

            var result = await _carService.GetDeleteCarModelAsync(carId);

            Assert.That(result, Is.Null);
        }
    }
}
