using CarShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Configuration
{
    public class CarCategoryConfiguration : IEntityTypeConfiguration<CarCategory>
    {
        public void Configure(EntityTypeBuilder<CarCategory> builder)
        {
            builder.HasData(this.SeedCarCategories());
        }

        private List<CarCategory> SeedCarCategories() 
        {
            List<CarCategory> carCategories = new List<CarCategory>()
            {
                new CarCategory()
                {
                    Id = Guid.Parse("5E5B45B5-6BCE-4E8C-A05A-EB6D5540F9CE"),
                    CategoryName = "SUV"
                },
                new CarCategory()
                {
                    Id = Guid.Parse("8E86C12D-4D99-4C26-BE13-BEFCA7323AB3"),
                    CategoryName = "Convertible"
                },
                new CarCategory()
                {
                    Id = Guid.Parse("91AC82E0-9AA7-4D53-BBA4-CD8128C0B629"),
                    CategoryName = "Hatchback"
				},
                new CarCategory()
                {
                    Id = Guid.Parse("DF2CDC1F-46C7-428B-A54B-E03EB0E33A7F"),
					CategoryName = "Sedan"
				},
                new CarCategory()
                {
                    Id = Guid.Parse("9C8E3EAD-80A2-45C6-AFBA-91248BAEBEF3"),
                    CategoryName = "Sports car"
				},
                new CarCategory()
                {
                    Id = Guid.Parse("264E1F65-36E4-44FB-9605-64BEC9B9ED7A"),
                    CategoryName = "Coupe"
				},
                new CarCategory()
                {
                    Id = Guid.Parse("A69FE7AC-6AD4-403F-BA76-EEFBC3A691C6"),
                    CategoryName = "Pickup truck"
				},
                new CarCategory()
                {
                    Id = Guid.Parse("47B3BA7C-8AAA-450D-BF9F-847106FC8E02"),
                    CategoryName = "Roadster"
				},
                new CarCategory()
                {
                    Id = Guid.Parse("EFDD48C4-FA58-48D9-8B86-0B9C3F0D64A6"),
                    CategoryName = "Minivan"
				}
            };

            return carCategories;
        }
    }
}
