using CarShop.Data.Models;
using CarShop.Data.Repository.Interfaces;
using CarShop.Services.Data.Interfaces;
using CarShop.Services.Mapping;
using CarShop.Web.ViewModels.Car;
using CarShop.Web.ViewModels.CarCategories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CarShop.Services.Data
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car, Guid> _carRepository;
        private readonly ICarCategoryService _carCategoryService;

        public CarService(IRepository<Car, Guid> carRepository,
            ICarCategoryService carCategoryService)
        {
            _carRepository = carRepository;
            _carCategoryService = carCategoryService;
        }
        public async Task<IEnumerable<AllCarsIndexViewModel>> IndexGetAllAsync(AllCarSearchFilterViewModel inputModel)
        {
            IQueryable<Car> allCarsQuery = _carRepository
                .GetAllAttached()
                .Where(c => c.IsDeleted == false);


			if (!String.IsNullOrWhiteSpace(inputModel.SearchQuery))
			{
				allCarsQuery = allCarsQuery
					.Where(c => c.Make.ToLower().Contains(inputModel.SearchQuery.ToLower()));
			}
			if (inputModel.PriceFilter != null)
			{
				allCarsQuery = allCarsQuery
					.Where(c => c.PricePerDay >= inputModel.PriceFilter);
			}

			if (inputModel.CurrentPage.HasValue &&
				inputModel.EntitiesPerPage.HasValue)
			{
				allCarsQuery = allCarsQuery
					.Skip(inputModel.EntitiesPerPage.Value * (inputModel.CurrentPage.Value - 1))
					.Take(inputModel.EntitiesPerPage.Value);
			}

			return await allCarsQuery
                .To<AllCarsIndexViewModel>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AddCarViewModel> GetCarCategoriesAsync()
        {
            return new AddCarViewModel
            {
                CarCategories = await _carCategoryService.GetCarCategoriesAsync()
            };
        }

        public async Task AddCarAsync(AddCarViewModel carModel)
        {
            Car car = new Car();
            AutoMapperConfig.MapperInstance.Map(carModel, car);
            
            car.IsAvailable = true;
            await _carRepository.AddAsync(car);
            await _carRepository.SaveChangesAsync();
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

        public async Task<EditCarViewModel?> GetEditCarModelAsync(Guid carId)
        {
            var model = await _carRepository 
                .GetAllAttached()
                .Where(c => c.IsDeleted == false)
                .Where(c => c.Id == carId)
                .AsNoTracking()
                .To<EditCarViewModel>()
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return null;
            }

            model!.CarCategories = await _carCategoryService.GetCarCategoriesAsync();
            return model;
        }

        public async Task<bool> UpdateCarAsync(Guid carId, EditCarViewModel carModel)
        {
            Car? entity = await _carRepository
                .GetByIdAsync(carId);   

            if (entity == null || entity.IsDeleted)
            {
                return false;
            }

            entity.Make = carModel.Make;
            entity.Model = carModel.Model;
            entity.ProductionYear = carModel.ProductionYear;
            entity.FuelConsumption = carModel.FuelConsumption;
            entity.TankVolume = carModel.TankVolume;
            entity.MaximumSpeed = carModel.MaximumSpeed;
            entity.CarImage = carModel.CarImage;
            entity.DoorsCount = carModel.DoorsCount;
            entity.SeatingCapacity = carModel.SeatingCapacity;
            entity.TransmissionType = carModel.TransmissionType;
            entity.PricePerDay = carModel.PricePerDay;
            entity.CarCategoryId = carModel.CarCategoryId;

            bool isUpdateSuccessful = _carRepository.Update(entity);
            await _carRepository.SaveChangesAsync();

            return isUpdateSuccessful;
        }

        public async Task<DeleteCarViewModel?> GetDeleteCarModelAsync(Guid carId)
        {
            return await _carRepository
                .GetAllAttached()
                .Where(c => c.IsDeleted == false)
                .Include(c => c.CarCategory)
                .To<DeleteCarViewModel>()
                .FirstOrDefaultAsync(c => c.Id == carId.ToString());
        }

        public async Task SoftDeleteCarAsync(Guid carId)
        {
            Car? car = await _carRepository
                .GetAllAttached()
                .Where(c => c.IsDeleted == false)
                .Where(c => c.Id == carId)
                .FirstOrDefaultAsync();

            if (car != null)
            {
                car.IsDeleted = true;
                await _carRepository.SaveChangesAsync();
            }
        }

        public async Task<int> GetCarsCountByFilterAsync(AllCarSearchFilterViewModel inputModel)
		{
			AllCarSearchFilterViewModel inputModelCopy = new AllCarSearchFilterViewModel()
			{
				CurrentPage = null,
				EntitiesPerPage = null,
				SearchQuery = inputModel.SearchQuery,
				PriceFilter = inputModel.PriceFilter,
			};
			int moviesCount = (await this.IndexGetAllAsync(inputModelCopy))
				.Count();
			return moviesCount;
		}
	}
}
