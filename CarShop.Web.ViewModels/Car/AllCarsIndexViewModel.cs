using CarShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Web.ViewModels.Car
{
    using Data.Models;
    public class AllCarsIndexViewModel : IMapFrom<Car>
    {
        public string Id { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? CarImage { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
    }
}