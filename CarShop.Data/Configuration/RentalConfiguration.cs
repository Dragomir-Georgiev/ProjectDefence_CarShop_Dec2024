using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Models;

namespace CarShop.Data.Configuration
{
	public class RentalConfiguration : IEntityTypeConfiguration<Rental>
	{
		public void Configure(EntityTypeBuilder<Rental> builder)
		{
			builder.HasData(this.SeedRentals());
		}

		private List<Rental> SeedRentals()
		{
			List<Rental> rentals = new List<Rental>()
			{
				new Rental
				{
					Id = Guid.Parse("DCF823B4-33F9-4102-A63D-AE28EE7E7708"),
					CarId = Guid.Parse("4590F15D-634B-4A10-9F69-32A88931922F"),
					StartDate = DateTime.UtcNow.AddDays(7),
					EndDate = DateTime.UtcNow.AddDays(10),
					TotalCost = 4541.84m
				},
				new Rental
				{
					Id = Guid.Parse("D58BF2B1-B3B1-4F63-9603-05BA7AD3E6F7"),
					CarId = Guid.Parse("CBC0F0DF-2FBF-4D87-AB77-C214EFA3E363"),
					StartDate = DateTime.UtcNow.AddDays(3),
					EndDate = DateTime.UtcNow.AddDays(7),
					TotalCost = 2151.95m
				},
				new Rental
				{
					Id = Guid.Parse("D599BCE1-6C7A-401A-9A5B-D10E0736E3D8"),
					CarId = Guid.Parse("0F3815D0-37B0-440D-978F-22FE3D9416CC"),
					StartDate = DateTime.UtcNow.AddDays(1),
					EndDate = DateTime.UtcNow.AddDays(3),
					TotalCost = 216m
				}
			};

			return rentals;
		}
	}
}
