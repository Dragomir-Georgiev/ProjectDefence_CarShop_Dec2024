using CarShop.Data.Models;
using CarShop.Data.Repository.Interfaces;
using CarShop.Services.Data.Interfaces;
using CarShop.Services.Mapping;
using CarShop.Web.ViewModels.Car;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Services.Data
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car, Guid> _carRepository;
        private readonly IRepository<CarCategory, Guid> _categoryRepository;

        public CarService(IRepository<Car, Guid> carRepository, 
            IRepository<CarCategory, Guid> categoryRepository)
        {
            _carRepository = carRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<AllCarsIndexViewModel>> IndexGetAllAsync()
        {
            IEnumerable<AllCarsIndexViewModel> cars = await _carRepository
                .GetAllAttached()
                .Where(c => c.IsDeleted == false)
                .To<AllCarsIndexViewModel>()
                .AsNoTracking()
                .ToListAsync();

            return cars;
        }

        public async Task<AddCarViewModel> GetCategoriesFromAddCarViewModel()
        {
            var categories = await _categoryRepository
            .GetAllAttached()
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName
            })
            .ToListAsync();

            return new AddCarViewModel
            {
                CarCategories = categories
            };
        }

        public async Task AddCarAsync(AddCarViewModel carModel)
        {
            Car car = new Car();
            AutoMapperConfig.MapperInstance.Map(carModel, car);
            
            car.IsAvailable = true;
            await _carRepository.AddAsync(car);
        }

        public async Task<CarDetailsViewModel?> GetCarDetailsByIdAsync(Guid id)
        {
            var car = await _carRepository
                .GetAllAttached()
                .Include(c => c.CarCategory)
                .Include(c => c.DamageReports)
                .Include(c => c.Feedbacks)
                .To<CarDetailsViewModel>()
                .FirstOrDefaultAsync(c => c.Id == id);

            return car;
        }
    }
}
