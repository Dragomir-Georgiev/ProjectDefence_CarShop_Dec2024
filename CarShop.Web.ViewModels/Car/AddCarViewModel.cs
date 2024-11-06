using CarShop.Data.Models;
using CarShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarShop.Common.EntityValidationConstants.Car;
namespace CarShop.Web.ViewModels.Car
{
    public class AddCarViewModel
    {
        [Required]
        [StringLength(MakeMaxLength, MinimumLength = MakeMinLength, ErrorMessage = "Make needs to be between 3 and 60 characters.")]
        public string Make { get; set; } = string.Empty;
        [Required]
        [StringLength(ModelMaxLenght, MinimumLength = ModelMinLenght, ErrorMessage = "Model needs to be between 3 and 60 characters.")]
        public string Model { get; set; } = string.Empty;
        [Required]
        [Range(ProductionYearMinRange, ProductionYearMaxRange, ErrorMessage = "Please enter a valid production year.")]
        public int ProductionYear { get; set; }
        [Required]
        [Range(FuelConsumptionMinRange, FuelConsumptionMaxRange, ErrorMessage = "Fuel consumption must be a positive number.")]
        public double FuelConsumption { get; set; }
        [Required]
        [Range(TankVolumeMinRange, TankVolumeMaxRange, ErrorMessage = "Tank volume must be a positive number.")]
        public double TankVolume { get; set; }
        [Required]
        [Range(MaximumSpeedMinRange, MaximumSpeedMaxRange, ErrorMessage = "Maximum speed must be a positive number.")]
        public int MaximumSpeed { get; set; }
        [MaxLength(CarImageMaxLength)]
        public string? CarImage { get; set; }
        [Required]
        [Range(DoorsCountMinRange, DoorsCountMaxRange, ErrorMessage = "Doors count must be between 1 and 10.")]
        public int DoorsCount { get; set; }
        [Required]
        [Range(SeatingCapacityMinRange, SeatingCapacityMaxRange, ErrorMessage = "Seating capacity must be between 1 and 20.")]
        public int SeatingCapacity { get; set; }
        [Required]
        public TransmissionType TransmissionType { get; set; }
        [Required]
        [Range((typeof(decimal)), PricePerDayMinRange, PricePerDayMaxRange, ErrorMessage = "Price per day must be a positive number.")]
        public decimal PricePerDay { get; set; }
        [Required]
        public Guid CarCategoryId { get; set; }
        public IEnumerable<CarCategory> CarCategories { get; set; } = new List<CarCategory>();
    }
}