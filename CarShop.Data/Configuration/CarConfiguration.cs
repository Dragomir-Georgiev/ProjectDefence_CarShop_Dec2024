using CarShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Models.Enums;

namespace CarShop.Data.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
			builder.HasData(this.SeedCars());
		}

        private List<Car> SeedCars()
        {
			List<Car> cars = new List<Car>()
			{
				new Car()
				{
					Id = Guid.Parse("4590F15D-634B-4A10-9F69-32A88931922F"),
					Make = "Porsche",
					Model = "911",
					ProductionYear = 2024,
					FuelConsumption = 13.8,
					TankVolume = 64,
					MaximumSpeed = 311,
					CarImage = "https://r44performance.com/cdn/shop/articles/R44Performance-Porsche-911-GT3RS.jpg?v=1710775245&width=1500",
					DoorsCount = 2,
					SeatingCapacity = 2,
					TransmissionType = TransmissionType.Automatic,
					PricePerDay = 1135.46m,
					IsAvailable = false,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("264E1F65-36E4-44FB-9605-64BEC9B9ED7A")
				},
				new Car()
				{
					Id = Guid.Parse("E3EA8915-979C-478F-B597-4B50E5F31CFD"),
					Make = "McLaren",
					Model = "750S Spider",
					ProductionYear = 2023,
					FuelConsumption = 12.2,
					TankVolume = 72,
					MaximumSpeed = 332,
					CarImage = "https://images.pistonheads.com/nimg/48142/blobid0.jpg",
					DoorsCount = 2,
					SeatingCapacity = 2,
					TransmissionType = TransmissionType.Automatic,
					PricePerDay = 1797.90m,
					IsAvailable = false,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("9C8E3EAD-80A2-45C6-AFBA-91248BAEBEF3")
				},
				new Car()
				{
					Id = Guid.Parse("EEA3A59B-1D08-47D5-82F5-863384B9DF71"),
					Make = "RAM",
					Model = "1500",
					ProductionYear = 2024,
					FuelConsumption = 15.7,
					TankVolume = 125,
					MaximumSpeed = 190,
					CarImage = "https://www.ramtrucks.com/content/dam/fca-brands/na/ramtrucks/en_us/2025/ram-1500/gallery/desktop/my25-ram-1500-gallery-open-1-d.jpg",
					DoorsCount = 4,
					SeatingCapacity = 6,
					TransmissionType = TransmissionType.Automatic,
					PricePerDay = 317.28m,
					IsAvailable = false,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("A69FE7AC-6AD4-403F-BA76-EEFBC3A691C6")
				},
				new Car()
				{
					Id = Guid.Parse("3F821603-C82C-4B46-BC94-8A246E5CA4C1"),
					Make = "Dodge",
					Model = "Caravan",
					ProductionYear = 2011,
					FuelConsumption = 13.8,
					TankVolume = 76,
					MaximumSpeed = 220,
					CarImage = "https://www.auto-data.net/images/f46/Dodge-Caravan-V-facelift-2011.jpg",
					DoorsCount = 5,
					SeatingCapacity = 7,
					TransmissionType = TransmissionType.Manual,
					PricePerDay = 31.78m,
					IsAvailable = false,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("EFDD48C4-FA58-48D9-8B86-0B9C3F0D64A6")
				},
				new Car()
				{
					Id = Guid.Parse("29480900-2B63-4503-8818-647FDE2A47E5"),
					Make = "Mazda",
					Model = "3",
					ProductionYear = 2022,
					FuelConsumption = 8.4,
					TankVolume = 50,
					MaximumSpeed = 204,
					CarImage = "https://www.motortrend.com/uploads/2022/03/2022-Mazda-Mazda3-Sedan-AWD-Turbo-29.jpg",
					DoorsCount = 4,
					SeatingCapacity = 5,
					TransmissionType = TransmissionType.Automatic,
					PricePerDay = 30,
					IsAvailable = false,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("DF2CDC1F-46C7-428B-A54B-E03EB0E33A7F")
				},
				new Car()
				{
					Id = Guid.Parse("8326B7A1-6A93-46C4-89EB-D1A50330E3B6"),
					Make = "Mazda",
					Model = "3",
					ProductionYear = 2022,
					FuelConsumption = 8.7,
					TankVolume = 50,
					MaximumSpeed = 204,
					CarImage = "https://www.thedrive.com/wp-content/uploads/2022/06/21/DSC00241.jpg?quality=85",
					DoorsCount = 5,
					SeatingCapacity = 5,
					TransmissionType = TransmissionType.Manual,
					PricePerDay = 35,
					IsAvailable = true,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("91AC82E0-9AA7-4D53-BBA4-CD8128C0B629")
				},
				new Car()
				{
					Id = Guid.Parse("E5A47D2A-68FE-4156-8F70-21072E04EB77"),
					Make = "Honda",
					Model = "CR-V",
					ProductionYear = 2022,
					FuelConsumption = 5.9,
					TankVolume = 53,
					MaximumSpeed = 190,
					CarImage = "https://manuals.plus/wp-content/uploads/2022/03/HONDA-2022-CR-V-FEATURD3.jpg",
					DoorsCount = 5,
					SeatingCapacity = 5,
					TransmissionType = TransmissionType.Automatic,
					PricePerDay = 37,
					IsAvailable = true,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("5E5B45B5-6BCE-4E8C-A05A-EB6D5540F9CE")
				},
				new Car()
				{
					Id = Guid.Parse("CBC0F0DF-2FBF-4D87-AB77-C214EFA3E363"),
					Make = "Audi",
					Model = "A5",
					ProductionYear = 2019,
					FuelConsumption = 7,
					TankVolume = 58,
					MaximumSpeed = 250,
					CarImage = "https://www.auto-data.net/images/f24/file8561751.jpg",
					DoorsCount = 2,
					SeatingCapacity = 4,
					TransmissionType = TransmissionType.Automatic,
					PricePerDay = 430.39m,
					IsAvailable = false,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("8E86C12D-4D99-4C26-BE13-BEFCA7323AB3")
				},
				new Car()
				{
					Id = Guid.Parse("0F3815D0-37B0-440D-978F-22FE3D9416CC"),
					Make = "BMW",
					Model = "Z4",
					ProductionYear = 2024,
					FuelConsumption = 7.9,
					TankVolume = 52,
					MaximumSpeed = 250,
					CarImage = "https://www.passportbmw.com/blogs/846/wp-content/uploads/2022/09/P90479453__mid.jpeg",
					DoorsCount = 2,
					SeatingCapacity = 2,
					TransmissionType = TransmissionType.Automatic,
					PricePerDay = 72,
					IsAvailable = false,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("47B3BA7C-8AAA-450D-BF9F-847106FC8E02")
				},
				new Car()
				{
					Id = Guid.Parse("41F5527C-C52B-409C-A6E8-74E8F6497C80"),
					Make = "Toyota",
					Model = "Camry",
					ProductionYear = 2023,
					FuelConsumption = 5.81,
					TankVolume = 60,
					MaximumSpeed = 205,
					CarImage = "",
					DoorsCount = 4,
					SeatingCapacity = 5,
					TransmissionType = TransmissionType.Automatic,
					PricePerDay = 54,
					IsAvailable = true,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("DF2CDC1F-46C7-428B-A54B-E03EB0E33A7F")
				},
				new Car()
				{
					Id = Guid.Parse("04F4C07E-045D-457E-AF60-B0397CF81225"),
					Make = "Honda",
					Model = "Civic Type R",
					ProductionYear = 2020,
					FuelConsumption = 8.4,
					TankVolume = 46,
					MaximumSpeed = 270,
					CarImage = "",
					DoorsCount = 5,
					SeatingCapacity = 4,
					TransmissionType = TransmissionType.Manual,
					PricePerDay = 0,
					IsAvailable = true,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("91AC82E0-9AA7-4D53-BBA4-CD8128C0B629")
				},
				new Car()
				{
					Id = Guid.Parse("77B5FE3D-BE73-4089-8512-B6665370A2EC"),
					Make = "Subaru",
					Model = "BRZ",
					ProductionYear = 2021,
					FuelConsumption = 9.5,
					TankVolume = 50,
					MaximumSpeed = 226,
					CarImage = "https://s3-ap-southeast-1.amazonaws.com/subaru.asia-cms/articles/logo_1b697b9c5550ddceb41469d84a27d60a.jpg",
					DoorsCount = 2,
					SeatingCapacity = 4,
					TransmissionType = TransmissionType.Automatic,
					PricePerDay = 45,
					IsAvailable = true,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("264E1F65-36E4-44FB-9605-64BEC9B9ED7A")
				},
				new Car()
				{
					Id = Guid.Parse("BA7F77E9-E054-4EC9-8F11-2D7346EA80B5"),
					Make = "Chevrolet",
					Model = "Silverado 1500",
					ProductionYear = 2022,
					FuelConsumption = 14.7,
					TankVolume = 90.8,
					MaximumSpeed = 183,
					CarImage = "https://dealerinspire-image-library-prod.s3.us-east-1.amazonaws.com/images/G91FpK6If8GqdDPnNyDDqhHR8SEG2pb5lVb3ghli.jpeg",
					DoorsCount = 4,
					SeatingCapacity = 5,
					TransmissionType = TransmissionType.Automatic,
					PricePerDay = 140,
					IsAvailable = true,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("A69FE7AC-6AD4-403F-BA76-EEFBC3A691C6")
				},
				new Car()
				{
					Id = Guid.Parse("99FED59F-DCE8-4359-8CCB-88EFA7781FAA"),
					Make = "BMW",
					Model = "3 Series",
					ProductionYear = 2022,
					FuelConsumption = 7.8,
					TankVolume = 59,
					MaximumSpeed = 250,
					CarImage = "https://parkers-images.bauersecure.com/wp-images/174840/bmw_3_series_050.jpg",
					DoorsCount = 4,
					SeatingCapacity = 5,
					TransmissionType = TransmissionType.Automatic,
					PricePerDay = 75,
					IsAvailable = false,
					IsDeleted = false,
					CarCategoryId = Guid.Parse("DF2CDC1F-46C7-428B-A54B-E03EB0E33A7F")
				}
			};

			return cars;
        }
    }
}
