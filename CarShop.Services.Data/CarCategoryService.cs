using CarShop.Data.Models;
using CarShop.Data.Repository.Interfaces;
using CarShop.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Data
{
    public class CarCategoryService : ICarCategoryService
    {
        private readonly IRepository<CarCategory, Guid> _categoryRepository;

        public CarCategoryService(IRepository<CarCategory, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<SelectListItem>> GetCarCategoriesAsync()
        {
            return await _categoryRepository
                .GetAllAttached()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName
                })
                .ToListAsync(); 
        }
    }
}
