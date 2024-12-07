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

            builder.HasData(SeedApplicationUserRental());
        }

        private List<ApplicationUserRental> SeedApplicationUserRental()
        {
            List<ApplicationUserRental> applicationUserRental = new List<ApplicationUserRental>()
            {
                new ApplicationUserRental()
                {
                    ApplicationUserId = Guid.Parse("4C2D88CD-675A-4904-A431-23A043E8313E"),
                    RentalId = Guid.Parse("DCF823B4-33F9-4102-A63D-AE28EE7E7708")
                },
				new ApplicationUserRental()
				{
					ApplicationUserId = Guid.Parse("4C2D88CD-675A-4904-A431-23A043E8313E"),
					RentalId = Guid.Parse("D58BF2B1-B3B1-4F63-9603-05BA7AD3E6F7")
				},
				new ApplicationUserRental()
				{
					ApplicationUserId = Guid.Parse("4C2D88CD-675A-4904-A431-23A043E8313E"),
					RentalId = Guid.Parse("D599BCE1-6C7A-401A-9A5B-D10E0736E3D8")
				}
			};

            return applicationUserRental;
        }
	}
}
