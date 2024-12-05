using CarShop.Data.Models;
using CarShop.Data.Repository.Interfaces;
using CarShop.Services.Data.Interfaces;
using CarShop.Web.ViewModels.Rental;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Data
{
    public class RentalService : IRentalService
    {
        private readonly IRepository<Car, Guid> _carRepository;
        private readonly IRepository<Rental, Guid> _rentalRepository;
        private readonly IRepository<ApplicationUserRental, object> _userRentalRepository;
        private readonly IRepository<DamageReport, Guid> _damageReportRepository;

        public RentalService(
            IRepository<Car, Guid> carRepository,
            IRepository<Rental, Guid> rentalRepository,
            IRepository<ApplicationUserRental, object> userRentalRepository,
            IRepository<DamageReport, Guid> damageReportRepository)
        {
            _carRepository = carRepository;
            _rentalRepository = rentalRepository;
            _userRentalRepository = userRentalRepository;
            _damageReportRepository = damageReportRepository;
        }

        public async Task<IndexRentalViewModel?> GetRentalIndexAsync(Guid carId)
        {
            var validCar = await _carRepository
                .FirstOrDefaultAsync(c => c.Id == carId);
            if (validCar == null)
            {
                return null;
            }

            var viewModel = new IndexRentalViewModel()
            {
                CarId = carId.ToString(),
                Make = validCar.Make,
                Model = validCar.Model,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
            };
            return viewModel;
        }
        public async Task<ConfirmRentalViewModel?> GetConfirmRentalIndexAsync(IndexRentalViewModel viewModel, Guid carId)
        {
            var validCar = await _carRepository
                .FirstOrDefaultAsync(c => c.Id == carId);
            if (validCar == null)
            {
                return null;
            }

            var totalRentDays = (viewModel.EndDate - viewModel.StartDate).Days + 1;
            var totalCost = totalRentDays * validCar.PricePerDay;

            var confirmViewModel = new ConfirmRentalViewModel()
            {
                CarId = viewModel.CarId,
                Make = validCar.Make,
                Model = validCar.Model,
                CarImage = validCar.CarImage ?? "/images/no-car-img.jpg",
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                TotalCost = totalCost,
            };
            return confirmViewModel;
        }
        public async Task<bool> AddRentalAsync(ConfirmRentalViewModel viewModel, Guid userId, Guid carId)
        {
            var validCar = await _carRepository
                .FirstOrDefaultAsync(c => c.Id == carId);
            if (validCar == null)
            {
                return false;
            }

            validCar.IsAvailable = false;

            var rental = new Rental()
            {
                Id = Guid.NewGuid(),
                CarId = carId,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                TotalCost = viewModel.TotalCost
            };

            rental.ApplicationUserRentals.Add(new ApplicationUserRental()
            {
                ApplicationUserId = userId,
                RentalId = rental.Id
            });

            await _rentalRepository.AddAsync(rental);
            await _rentalRepository.SaveChangesAsync();
            return true;
        }
        public async Task<List<RentedCarViewModel>> GetRentedCarsAsync(Guid userId)
        {
            var rentedCars = await _rentalRepository
                .GetAllAttached()
                .Where(r => r.ApplicationUserRentals.Any(ur => ur.ApplicationUserId == userId))
                .Include(r => r.Car)
                .Select(r => new RentedCarViewModel()
                {
                    RentalId = r.Id,
                    Make = r.Car.Make,
                    Model = r.Car.Model,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    TotalCost = r.TotalCost,
                    CarImage = r.Car.CarImage ?? "/images/no-car-img.jpg"
                })
                .AsNoTracking()
                .ToListAsync();
            return rentedCars;
        }
        public async Task<bool> RemoveRentalAsync(Guid rentalId, Guid userId)
        {
            var rental = await _rentalRepository
                .GetAllAttached()
                .Include(r => r.Car)
                .Include(r => r.ApplicationUserRentals)
                .FirstOrDefaultAsync(r => r.Id == rentalId);

            if (rental == null || !rental.ApplicationUserRentals.Any(ur => ur.ApplicationUserId == userId))
            {
                return false;
            }

            var userRental = await _userRentalRepository
                .FirstOrDefaultAsync(r => r.RentalId == rentalId);

            if (userRental == null)
            {
                return false;
            }

            if (await _damageReportRepository.FirstOrDefaultAsync(dr => dr.CarId == rental.CarId) == null)
            {
                rental.Car.IsAvailable = true;
            }

            _userRentalRepository.Delete(userRental);
            _rentalRepository.Delete(rental);
            await _rentalRepository.SaveChangesAsync();
            return true;
        }
    }
}
