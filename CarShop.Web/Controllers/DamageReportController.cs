﻿using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services.Data.Interfaces;
using CarShop.Web.ViewModels.DamageReport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Web.Controllers
{
    public class DamageReportController : BaseController
    {
        private readonly IDamageReportService _damageReportService;
        public DamageReportController(IDamageReportService damageReportService)
        {
            _damageReportService = damageReportService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid carId)
        {
            DamageReportIndexViewModel? viewModel = await _damageReportService.GetDamageReportsByCarIdAsync(carId);
            if (viewModel == null)
            {
                return RedirectToAction("Details", "Car", new { id = carId.ToString() });
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DamageReportFormViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { carId = form.CarId });
            }

            await _damageReportService.AddDamageReportAsync(form);
            return RedirectToAction("Index", new { carId = form.CarId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            DamageReportFormViewModel? viewModel = await _damageReportService.GetDamageReportForEditAsync(id);
            if (viewModel == null)
            {
                return RedirectToAction("Index", new { carId = id });
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DamageReportFormViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { carId = form.CarId });
            }

            await _damageReportService.EditDamageReportAsync(form);

            return RedirectToAction("Index", new { carId = form.CarId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _damageReportService.RemoveDamageReportAsync(id);

            return RedirectToAction("Index", new { carId = id });
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var carsWithDamageReports = await _damageReportService.GetAllCarsWithDamageReportsAsync();
            return View(carsWithDamageReports);
        }
    }
}
