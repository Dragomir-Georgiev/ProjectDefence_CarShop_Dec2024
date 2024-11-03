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
    public class ApplicationUserRentalConfiguration : IEntityTypeConfiguration<ApplicationUserRental>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRental> builder)
        {
            builder
            .HasOne(cd => cd.Rental)
            .WithMany(cd => cd.ApplicationUserRentals)
            .HasForeignKey(cd => cd.RentalId)
            .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(cd => cd.ApplicationUser)
                .WithMany(cd => cd.ApplicationUserRentals)
                .HasForeignKey(cd => cd.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
