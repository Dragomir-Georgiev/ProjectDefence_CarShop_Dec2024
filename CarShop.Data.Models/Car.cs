using CarShop.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static CarShop.Common.EntityValidationConstants.Car;

namespace CarShop.Data.Models
{
    public class Car
    {
        [Key]
        [Comment("Car unique identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(MakeMaxLength)]
        [Comment("The brand of the company that made the car")]
        public string Make { get; set; } = null!;
        [Required]
        [MaxLength(ModelMaxLenght)]
        [Comment("The name of the car")]
        public string Model { get; set; } = null!;
        [Required]
        [Comment("Manufacturing year of the car")]
        public int ProductionYear { get; set; }
        [Required]
        [Comment("The fuel consumption of the car")]
        public double FuelConsumption { get; set; }
        [Required]
        [Comment("The tank volume of the car")]
        public double TankVolume { get; set; }
        [Required]
        [Comment("Car maximum speed")]
        public int MaximumSpeed { get; set; }
        [Comment("Picture of the car")]
        public string? CarImage { get; set; }
        [Required]
        [Comment("Total amount of doors of the car")]
        public int DoorsCount { get; set; }
        [Required]
        [Comment("The maximum seating capacity of the car")]
        public int SeatingCapacity { get; set; }
        [Required]
        [Comment("Transmission type of the car")]
        public TransmissionType TransmissionType { get; set; }
        [Required]
        [Comment("Price for the car per day")]
        public decimal PricePerDay { get; set; }
        [Comment("Availability of the car")]
        public bool IsAvailable { get; set; } = true;
        [Comment("Has the car been removed or not removed from the list of available rental cars")]
        public bool IsDeleted { get; set; }
        [Comment("The unique identifier of the category of the car")]
        public Guid CarCategoryId { get; set; }
        [ForeignKey(nameof(CarCategoryId))]
        public CarCategory CarCategory { get; set; } = null!;

        public ICollection<Rental> Rentals { get; set; } = new HashSet<Rental>();
        public ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();
        public ICollection<CarDiscount> CarDiscounts { get; set; } = new HashSet<CarDiscount>();
        public ICollection<DamageReport> DamageReports { get; set; } = new HashSet<DamageReport>();
    }
}
