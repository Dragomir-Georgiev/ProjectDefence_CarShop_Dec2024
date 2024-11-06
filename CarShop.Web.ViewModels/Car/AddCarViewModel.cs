using CarShop.Data.Models;
using CarShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Web.ViewModels.Car
{
    public class AddCarViewModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Make cannot exceed 100 characters.")]
        public string Make { get; set; } = string.Empty;

        [Required]
        [MaxLength(100, ErrorMessage = "Model cannot exceed 100 characters.")]
        public string Model { get; set; } = string.Empty;

        [Required]
        [Range(1886, 2100, ErrorMessage = "Please enter a valid production year.")]
        public int ProductionYear { get; set; }

        [Required]
        [Range(0.1, 100, ErrorMessage = "Fuel consumption must be a positive number.")]
        public double FuelConsumption { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Tank volume must be a positive number.")]
        public double TankVolume { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "Maximum speed must be a positive number.")]
        public int MaximumSpeed { get; set; }

        [MaxLength(255)]
        public string? CarImage { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Doors count must be between 1 and 10.")]
        public int DoorsCount { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Seating capacity must be between 1 and 20.")]
        public int SeatingCapacity { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        [Range(0.1, 10000, ErrorMessage = "Price per day must be a positive number.")]
        public decimal PricePerDay { get; set; }

        [Required]
        public Guid CarCategoryId { get; set; }

        public IEnumerable<CarCategory> CarCategories { get; set; } = new List<CarCategory>();

    }
}
