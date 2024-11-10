using CarShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Web.ViewModels.Car
{
    public class CarDetailsViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Make { get; set; } = null!;
        [Required]
        public string Model { get; set; } = null!;
        public int ProductionYear { get; set; }
        public double FuelConsumption { get; set; }
        public double TankVolume { get; set; }
        public int MaximumSpeed { get; set; }
        public int DoorsCount { get; set; }
        public int SeatingCapacity { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public decimal PricePerDay { get; set; }
        [Required]
        public string CategoryName { get; set; } = null!;
        public string? CarImage { get; set; }
    }
}
