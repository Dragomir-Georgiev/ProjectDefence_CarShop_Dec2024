﻿using CarShop.Data.Models;
using CarShop.Data.Repository.Interfaces;
using CarShop.Services.Data.Interfaces;
using CarShop.Services.Mapping;
using CarShop.Web.ViewModels.Car;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<EditCarViewModel?> GetEditCarModelAsync(Guid carId)
        {
            var model = await _carRepository 
                .GetAllAttached()
                .Where(c => c.IsDeleted == false)
                .Where(c => c.Id == carId)
                .AsNoTracking()
                .Select(c => new EditCarViewModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    CarCategoryId = c.CarCategoryId,
                    TransmissionType = c.TransmissionType,
                    PricePerDay = c.PricePerDay,
                    MaximumSpeed = c.MaximumSpeed,
                    CarImage = c.CarImage,
                    DoorsCount = c.DoorsCount,
                    FuelConsumption = c.FuelConsumption,
                    ProductionYear = c.ProductionYear,
                    SeatingCapacity = c.SeatingCapacity,
                    TankVolume = c.TankVolume,
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return null;
            }

            model!.CarCategories = await _categoryRepository
                .GetAllAttached()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName
                })
                .ToListAsync();

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

            return await _carRepository.UpdateAsync(entity);
        }
    }
}
