using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Data.Interfaces
{
    public interface ICarCategoryService
    {
        Task<List<SelectListItem>> GetCarCategoriesAsync();
    }
}
