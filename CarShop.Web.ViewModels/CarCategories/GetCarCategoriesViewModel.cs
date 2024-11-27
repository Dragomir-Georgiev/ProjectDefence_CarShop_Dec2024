using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Web.ViewModels.CarCategories
{
    public class GetCarCategoriesViewModel
    {
        [Required]
        public Guid CarCategoryId { get; set; }
        public IEnumerable<SelectListItem> CarCategories { get; set; } = new List<SelectListItem>();
    }
}
