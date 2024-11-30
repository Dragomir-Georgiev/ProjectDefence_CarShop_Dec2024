using CarShop.Data.Models;
using CarShop.Data.Repository.Interfaces;
using CarShop.Services.Data.Interfaces;
using CarShop.Web.ViewModels.DamageReport;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Data
{
    public class DamageReportService : IDamageReportService
    {
        private readonly IRepository<DamageReport, Guid> _damageReportRepository;
        private readonly IRepository<Car, Guid> _carRepository;

        public DamageReportService(IRepository<DamageReport, Guid> damageReportRepository, IRepository<Car, Guid> carRepository)
        {
            _damageReportRepository = damageReportRepository;
            _carRepository = carRepository;
        }
        public async Task<DamageReportIndexViewModel?> GetDamageReportsByCarIdAsync(Guid carId)
        {
            var car = await _carRepository
                .GetAllAttached()
                .Include(c => c.DamageReports)
                .FirstOrDefaultAsync(c => c.Id == carId);

            if (car == null)
            {
                return null;
            }

            var viewModel = new DamageReportIndexViewModel()
            {
                CarId = car.Id,
                CarMakeModel = $"{car.Make} {car.Model}",
                DamageReport = car.DamageReports.Select(dr => new DamageReportViewModel()
                {
                    Id = dr.Id,
                    Description = dr.Description,
                    ReportedDate = dr.ReportedDate,
                    CostEstimation = dr.CostEstimation,
                }).FirstOrDefault()!,
            };

            return viewModel;
        }
        public async Task AddDamageReportAsync(DamageReportEditViewModel form)
        {
            var validCar = await _carRepository.GetByIdAsync(form.CarId);
            if (validCar == null)
            {
                throw new ArgumentException("Invalid car ID");
            }

            validCar.IsAvailable = false;

            var damageReport = new DamageReport()
            {
                CarId = form.CarId,
                Description = form.Description,
                ReportedDate = DateTime.Now,
                CostEstimation = form.CostEstimation,
            };

            await _damageReportRepository.AddAsync(damageReport);
            await _damageReportRepository.SaveChangesAsync();
        }

        public async Task<DamageReportEditViewModel?> GetDamageReportForEditAsync(Guid reportId)
        {
            var report = await _damageReportRepository.GetByIdAsync(reportId);

            if (report == null)
            {
                return null;
            }

            return new DamageReportEditViewModel
            {
                Id = report.Id,
                CarId = report.CarId,
                Description = report.Description,
                CostEstimation = report.CostEstimation,
            };
        }
        public async Task EditDamageReportAsync(DamageReportEditViewModel form)
        {
            var report = await _damageReportRepository.GetByIdAsync(form.Id);
            if (report == null)
            {
                throw new ArgumentException("Invalid damage report ID");
            }

            report.Description = form.Description;
            report.CostEstimation = form.CostEstimation;
            await _damageReportRepository.SaveChangesAsync();
        }

        public async Task RemoveDamageReportAsync(Guid reportId)
        {
            var report = await _damageReportRepository.GetByIdAsync(reportId);
            if (report == null)
            {
                throw new ArgumentException("Invalid damage report ID");
            }

            var validCar = await _carRepository.GetByIdAsync(report.CarId);
            if (validCar == null)
            {
                throw new ArgumentException("Invalid car ID");
            }

            if (!validCar.Rentals.Any())
            {
                validCar.IsAvailable = true;
            }

            _damageReportRepository.Delete(report);
            await _damageReportRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<DamageReportIndexViewModel>> GetAllCarsWithDamageReportsAsync()
        {
            var carsWithDamageReports = await _carRepository
                .GetAllAttached()
                .Include(c => c.DamageReports)
                .Where(c => c.DamageReports.Any())
                .Select(c => new DamageReportIndexViewModel()
                {
                    CarId = c.Id,
                    CarMakeModel = $"{c.Make} {c.Model}",
                    DamageReport = c.DamageReports.Select(dr => new DamageReportViewModel
                    {
                        Id = dr.Id,
                        Description = dr.Description,
                        ReportedDate = dr.ReportedDate,
                        CostEstimation = dr.CostEstimation
                    }).FirstOrDefault()!
                })
                .ToListAsync();

            return carsWithDamageReports;
        }
    }
}
