using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Web.ViewModels.DamageReport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Web.Controllers
{
    public class DamageReportController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public DamageReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid carId)
        {
            var car = await _context.Cars
            .Include(c => c.DamageReports)
            .FirstOrDefaultAsync(c => c.Id == carId);

            if (car == null)
            {
                return this.RedirectToAction("Details", "Car", new { id = carId.ToString() });
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
                })
                .FirstOrDefault()!,
            };
            

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DamageReportFormViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { carId = form.CarId });
            }

            var validCar = await _context.Cars
                .FirstOrDefaultAsync(c => c.Id == form.CarId);
            if (validCar == null)
            {
                return this.RedirectToAction("Index", "Car");
            }

            validCar.IsAvailable = false;

            var damageReport = new DamageReport()
            {
                CarId = form.CarId,
                Description = form.Description,
                ReportedDate = DateTime.Now,
                CostEstimation = form.CostEstimation,
            };

            await _context.DamageReports.AddAsync(damageReport);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { carId = form.CarId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var report = await _context.DamageReports.FirstOrDefaultAsync(dr => dr.Id == id);
            if (report == null)
            {
                return RedirectToAction("Index", new { carId = report!.CarId });
            }

            var viewModel = new DamageReportFormViewModel
            {
                Id = report.Id,
                CarId = report.CarId,
                Description = report.Description,
                CostEstimation = report.CostEstimation,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DamageReportFormViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { carId = form.CarId });
            }

            var report = await _context.DamageReports.FirstOrDefaultAsync(dr => dr.Id == form.Id);
            if (report == null)
            {
                return RedirectToAction("Index", new { carId = form.CarId });
            }

            report.Description = form.Description;
            report.CostEstimation = form.CostEstimation;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { carId = report.CarId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(Guid id)
        {
            var report = await _context.DamageReports.FirstOrDefaultAsync(dr => dr.Id == id);
            if (report == null)
            {
                return RedirectToAction("Index", new { carId = report!.CarId });
            }

            var validCar = await _context.Cars
                .FirstOrDefaultAsync(c => c.Id == report!.CarId);
            if (validCar == null)
            {
                return this.RedirectToAction("Index", "Car");
            }

            //TODO check if the car has any rentals before making it available

            validCar.IsAvailable = true;

            _context.DamageReports.Remove(report);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { carId = report.CarId });
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var carsWithDamageReports = await _context.Cars
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

            return View(carsWithDamageReports);
        }
    }
}
