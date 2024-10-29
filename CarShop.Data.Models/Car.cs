using CarShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public double FuelConsumption { get; set; }
        public double TankVolume { get; set; }
        public int MaximumSpeed { get; set; }
        public string CarImage { get; set; }
        public int DoorsCount { get; set; }
        public int SeatingCapacity { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CarCategoryId { get; set; }
        public CarCategory CarCategory { get; set; }
    }
}
