using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static CarShop.Common.EntityValidationConstants.Car;
using static CarShop.Common.EntityValidationMessages.Car;

namespace CarShop.Web.ViewModels.Car
{
    public class AllCarSearchFilterViewModel
    {
        public IEnumerable<AllCarsIndexViewModel>? Cars {  get; set; }
        public string? SearchQuery { get; set; }
        [Range((typeof(decimal)),PricePerDayMinRange, PricePerDayMaxRange, ErrorMessage = PricePerDayRequiredMessage)]
        public decimal? PriceFilter { get; set; }
        public int? CurrentPage { get; set; } = 1;
        public int? EntitiesPerPage { get; set; } = 6;
        public int? TotalPages { get; set; }
    }
}
