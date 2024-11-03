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
    public class CarDiscountConfiguration : IEntityTypeConfiguration<CarDiscount>
    {
        public void Configure(EntityTypeBuilder<CarDiscount> builder)
        {
            builder
                .HasOne(cd => cd.Car)
                .WithMany(cd => cd.CarDiscounts)
                .HasForeignKey(cd => cd.CarId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(cd => cd.Discount)
                .WithMany(cd => cd.CarDiscounts)
                .HasForeignKey(cd => cd.DiscountId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
