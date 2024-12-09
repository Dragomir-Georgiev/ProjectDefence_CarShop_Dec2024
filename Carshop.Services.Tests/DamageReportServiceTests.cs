using CarShop.Data.Models;
using CarShop.Data.Repository.Interfaces;
using CarShop.Services.Data;
using CarShop.Services.Mapping;
using CarShop.Web.ViewModels;
using CarShop.Web.ViewModels.DamageReport;
using MockQueryable;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carshop.Services.Tests
{
    [TestFixture]
    public class DamageReportServiceTests
    {
        private Mock<IRepository<DamageReport, Guid>> _mockDamageReportRepository;
        private Mock<IRepository<Car, Guid>> _mockCarRepository;
        private DamageReportService _damageReportService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);
        }

        [SetUp]
        public void SetUp()
        {
            _mockDamageReportRepository = new Mock<IRepository<DamageReport, Guid>>();
            _mockCarRepository = new Mock<IRepository<Car, Guid>>();
            _damageReportService = new DamageReportService(_mockDamageReportRepository.Object, _mockCarRepository.Object);
        }

        [Test]
        public async Task GetDamageReportsByCarIdAsyncShouldReturnTheViewModelIfTheCarHasDamageReports()
        {
            var carId = Guid.Parse("6911925C-A9E9-47C1-B52C-EE21E279A976");
            var damageReports = new List<DamageReport>
            {
                new DamageReport() { Id = Guid.Parse("30894F6B-BA39-45D3-820A-46777D5D380B"), Description = "Scratch", ReportedDate = DateTime.Now, CostEstimation = 100 }
            };

            var cars = new List<Car>
            {
                new Car() { Id = carId, Make = "Tesla", Model = "Model 3", DamageReports = damageReports }
            }
            .BuildMock();

            _mockCarRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(cars);

            var result = await _damageReportService.GetDamageReportsByCarIdAsync(carId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.CarId, Is.EqualTo(carId));
            Assert.That(result.CarMakeModel, Is.EqualTo("Tesla Model 3"));
            Assert.That(result.DamageReport.Id.ToString().ToLower(), Is.EqualTo(damageReports.First().Id.ToString().ToLower()));
        }

        [Test]
        public async Task GetDamageReportsByCarIdAsyncShouldReturnNullIfTheCarDoesNotExist()
        {
            var carId = Guid.Parse("6911925C-A9E9-47C1-B52C-EE21E279A976");

            _mockCarRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(new List<Car>().BuildMock());

            var result = await _damageReportService.GetDamageReportsByCarIdAsync(carId);

            Assert.That(result, Is.Null);
            _mockCarRepository.Verify(repo => repo.GetAllAttached(), Times.Once);
        }

        [Test]
        public async Task AddDamageReportAsyncShouldAddTheReportAndMarkTheCarUnavailable()
        {
            var carId = Guid.Parse("6911925C-A9E9-47C1-B52C-EE21E279A976");
            var carModel = new Car { Id = carId, IsAvailable = true, DamageReports = new List<DamageReport>() };

            _mockCarRepository
                .Setup(repo => repo.GetByIdAsync(carId))
                .ReturnsAsync(carModel);

            var form = new DamageReportEditViewModel
            {
                CarId = carId,
                Description = "Flat tire",
                CostEstimation = 50
            };

            _mockDamageReportRepository
                .Setup(repo => repo.AddAsync(It.IsAny<DamageReport>()))
                .Callback<DamageReport>(damageReport =>
                {
                    carModel.DamageReports.Add(damageReport);
                });

            await _damageReportService.AddDamageReportAsync(form);

            Assert.That(carModel.IsAvailable, Is.False);
            Assert.That(carModel.DamageReports.First().CarId.ToString().ToLower(), Is.EqualTo(carId.ToString().ToLower()));
        }

        [Test]
        public void AddDamageReportAsyncShouldThrowArgumentExceptionIfTheCarIsNull()
        {
            var carId = Guid.Parse("6911925C-A9E9-47C1-B52C-EE21E279A976");
            
            var emptyCars = new List<Car>()
                .BuildMock();

            _mockCarRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(emptyCars);

            var form = new DamageReportEditViewModel
            {
                CarId = carId,
                Description = "Flat tire",
                CostEstimation = 50
            };

            Assert.That(Assert.ThrowsAsync<ArgumentException>( async () => await _damageReportService.AddDamageReportAsync(form)).Message, Is.EqualTo("Invalid car ID"));
        }

        [Test]
        public async Task GetDamageReportForEditAsyncShouldReturnViewModelWhenTheReportExists()
        {
            var reportId = Guid.Parse("6911925C-A9E9-47C1-B52C-EE21E279A976");
            var report = new DamageReport { Id = reportId, Description = "Scratch", CostEstimation = 200 };

            _mockDamageReportRepository
                .Setup(repo => repo.GetByIdAsync(reportId))
                .ReturnsAsync(report);

            var result = await _damageReportService.GetDamageReportForEditAsync(reportId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(reportId));
            Assert.That(result.Description, Is.EqualTo("Scratch"));
            Assert.That(result.CostEstimation, Is.EqualTo(200));
        }

        [Test]
        public async Task GetDamageReportForEditAsyncShouldReturnNullIfTheReportDoesNotExist()
        {
            var reportId = Guid.Parse("6911925C-A9E9-47C1-B52C-EE21E279A976");

#pragma warning disable CS8620
            _mockDamageReportRepository
                .Setup(repo => repo.GetByIdAsync(reportId))
                .ReturnsAsync((DamageReport?)null);
#pragma warning restore CS8620

            var result = await _damageReportService.GetDamageReportForEditAsync(reportId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task EditDamageReportAsyncShouldUpdateTheReport()
        {
            var reportId = Guid.Parse("6911925C-A9E9-47C1-B52C-EE21E279A976");
            var report = new DamageReport { Id = reportId, Description = "Scratch", CostEstimation = 200 };

            _mockDamageReportRepository
                .Setup(repo => repo.GetByIdAsync(reportId))
                .ReturnsAsync(report);

            var form = new DamageReportEditViewModel
            {
                Id = reportId,
                Description = "Updated Scratch",
                CostEstimation = 250
            };

            await _damageReportService.EditDamageReportAsync(form);

            Assert.That(report.Id.ToString().ToLower(), Is.EqualTo(reportId.ToString().ToLower()));
            Assert.That(report.Description, Is.EqualTo("Updated Scratch"));
            Assert.That(report.CostEstimation, Is.EqualTo(250));
        }

        [Test]
        public void EditDamageReportAsyncShouldThrowArgumentExceptionIfTheReportDoesNotExist()
        {
            var reportId = Guid.Parse("6911925C-A9E9-47C1-B52C-EE21E279A976");

            var damageReports = new List<DamageReport>()
                .BuildMock();

            _mockDamageReportRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(damageReports);

            var form = new DamageReportEditViewModel
            {
                Id = reportId,
                Description = "Flat tire",
                CostEstimation = 50
            };

            Assert.That(Assert.ThrowsAsync<ArgumentException>(async () => await _damageReportService.EditDamageReportAsync(form)).Message, Is.EqualTo("Invalid damage report ID"));
        }

        [Test]
        public async Task RemoveDamageReportAsyncShouldDeleteTheReportAndMarkTheCarAvailableWhenNoRentalsExist()
        {
            var reportId = Guid.Parse("9D84A35F-7B88-4EAC-9404-DAC5E359B093");
            var carId = Guid.Parse("0ED56E57-DDE7-4B91-BF52-B1FECA740318");
            var report = new DamageReport { Id = reportId, CarId = carId };
            var car = new Car { Id = carId, Rentals = new List<Rental>(), IsAvailable = false };

            _mockDamageReportRepository
                .Setup(repo => repo.GetByIdAsync(reportId))
                .ReturnsAsync(report);

            _mockCarRepository
                .Setup(repo => repo.GetByIdAsync(carId))
                .ReturnsAsync(car);

            await _damageReportService.RemoveDamageReportAsync(reportId);

            Assert.That(car.IsAvailable, Is.True);
        }
    }
}
