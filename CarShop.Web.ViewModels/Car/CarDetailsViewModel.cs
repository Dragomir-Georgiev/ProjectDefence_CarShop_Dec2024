using CarShop.Data.Models.Enums;
using CarShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Web.ViewModels.Car
{
    using AutoMapper;
    using Data.Models;
    public class CarDetailsViewModel : IMapFrom<Car> , IHaveCustomMappings
    {
        public Guid Id { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int ProductionYear { get; set; }
        public double FuelConsumption { get; set; }
        public double TankVolume { get; set; }
        public int MaximumSpeed { get; set; }
        public int DoorsCount { get; set; }
        public int SeatingCapacity { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public decimal PricePerDay { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? CarImage { get; set; }
        public bool IsAvailable { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, CarDetailsViewModel>()
                .ForMember(c => c.CategoryName, x => x.MapFrom(s => s.CarCategory.CategoryName));
        }
    }
}
