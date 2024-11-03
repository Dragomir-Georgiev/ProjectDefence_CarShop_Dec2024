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

        public List<CarCategory> SeedCarCategories() 
        {
            List<CarCategory> carCategories = new List<CarCategory>()
            {
                new CarCategory()
                {
                    CategoryName = "SUV"
                },
                new CarCategory()
                {
                    CategoryName = "Convertible"
                },
                new CarCategory()
                {
                    CategoryName = "Hatchback"
                },
                new CarCategory()
                {
                    CategoryName = "Sedan"
                },
                new CarCategory()
                {
                    CategoryName = "Sports car"
                },
                new CarCategory()
                {
                    CategoryName = "Coupe"
                },
                new CarCategory()
                {
                    CategoryName = "Pickup truck"
                },
                new CarCategory()
                {
                    CategoryName = "Roadster"
                },
                new CarCategory()
                {
                    CategoryName = "Minivan"
                }
            };

            return carCategories;
        }
    }
}
