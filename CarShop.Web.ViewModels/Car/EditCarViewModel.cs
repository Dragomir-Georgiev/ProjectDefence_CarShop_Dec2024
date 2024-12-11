using CarShop.Data.Models;
using CarShop.Data.Models.Enums;
using CarShop.Services.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarShop.Common.EntityValidationConstants.Car;
using static CarShop.Common.EntityValidationMessages.Car;

namespace CarShop.Web.ViewModels.Car
{
    using CarShop.Data.Models;
    public class EditCarViewModel : IMapFrom<Car>
    {
        [Required]
        public string Id { get; set; } = null!;
        [Required]
        [StringLength(MakeMaxLength, MinimumLength = MakeMinLength, ErrorMessage = MakeRequiredMessage)]
        public string Make { get; set; } = string.Empty;
        [Required]
        [StringLength(ModelMaxLenght, MinimumLength = ModelMinLenght, ErrorMessage = ModelRequiredMessage)]
        public string Model { get; set; } = string.Empty;
        [Required]
        [Range(ProductionYearMinRange, ProductionYearMaxRange, ErrorMessage = ProductionYearRequiredMessage)]
        public int ProductionYear { get; set; }
        [Required]
        [Range(FuelConsumptionMinRange, FuelConsumptionMaxRange, ErrorMessage = FuelConsumptionRequiredMessage)]
        public double FuelConsumption { get; set; }
        [Required]
        [Range(TankVolumeMinRange, TankVolumeMaxRange, ErrorMessage = TankVolumeRequiredMessage)]
        public double TankVolume { get; set; }
        [Required]
        [Range(MaximumSpeedMinRange, MaximumSpeedMaxRange, ErrorMessage = MaximumSpeedRequiredMessage)]
        public int MaximumSpeed { get; set; }
        [MaxLength(CarImageMaxLength)]
        public string? CarImage { get; set; }
        [Required]
        [Range(DoorsCountMinRange, DoorsCountMaxRange, ErrorMessage = DoorsCountRequiredMessage)]
        public int DoorsCount { get; set; }
        [Required]
        [Range(SeatingCapacityMinRange, SeatingCapacityMaxRange, ErrorMessage = SeatingCapacityRequiredMessage)]
        public int SeatingCapacity { get; set; }
        [Required]
        public TransmissionType TransmissionType { get; set; }
        [Required]
        [Range((typeof(decimal)), PricePerDayMinRange, PricePerDayMaxRange, ErrorMessage = PricePerDayRequiredMessage)]
        public decimal PricePerDay { get; set; }
        [Required]
        public Guid CarCategoryId { get; set; }
        public IEnumerable<SelectListItem> CarCategories { get; set; } = new List<SelectListItem>();
    }
}
