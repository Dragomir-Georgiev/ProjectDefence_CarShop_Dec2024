using CarShop.Data.Models;
using CarShop.Data.Repository.Interfaces;
using CarShop.Services.Data.Interfaces;
using CarShop.Services.Mapping;
using CarShop.Web.ViewModels.Car;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Services.Data
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car, Guid> _carRepository;

        public CarService(IRepository<Car, Guid> carRepository)
        {
            _carRepository = carRepository;
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
        public Task AddCarAsync(AddCarViewModel carModel)
        {
            throw new NotImplementedException();
        }

        public Task<CarDetailsViewModel> GetCarDetailsByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

    }
}
