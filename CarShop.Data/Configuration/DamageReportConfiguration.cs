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
	public class DamageReportConfiguration : IEntityTypeConfiguration<DamageReport>
	{
		public void Configure(EntityTypeBuilder<DamageReport> builder)
		{
			builder.HasData(this.SeedDamageReports());
		}

		private List<DamageReport> SeedDamageReports()
		{
			List<DamageReport> damageReports = new List<DamageReport>()
			{
				new DamageReport()
				{
					Id = Guid.Parse("CDCA012A-0A63-4B99-BB3E-45AEF2B5D1A3"),
					Description = "Front bumper is severely dented due to a collision with a pole.",
					ReportedDate = DateTime.UtcNow.AddDays(-3),
					CostEstimation = 1200.50m,
					CarId = Guid.Parse("99FED59F-DCE8-4359-8CCB-88EFA7781FAA"),
				},
				new DamageReport()
				{
					Id = Guid.Parse("A03FAD62-483F-4F88-B7E9-1C857C5650DE"),
					Description = "Rear window shattered after an attempted break-in at the parking lot.",
					ReportedDate = DateTime.UtcNow.AddDays(-10),
					CostEstimation = 600.00m,
					CarId = Guid.Parse("3F821603-C82C-4B46-BC94-8A246E5CA4C1")
				},
				new DamageReport()
				{
					Id = Guid.Parse("6E92A04A-C225-4D2A-A0FE-C85FFA59E726"),
					Description = "Left side mirror broken and scratches along the driver-side door.",
					ReportedDate = DateTime.UtcNow.AddDays(-5),
					CostEstimation = 750.25m,
					CarId = Guid.Parse("29480900-2B63-4503-8818-647FDE2A47E5")
				},
				new DamageReport()
				{
					Id = Guid.Parse("A8FAAFB7-9CD4-49FC-8EDC-D1D76C37DB8A"),
					Description = "Hood is dented and paint is chipped from debris falling on the car.",
					ReportedDate = DateTime.UtcNow.AddDays(-15),
					CostEstimation = 1400.00m,
					CarId = Guid.Parse("EEA3A59B-1D08-47D5-82F5-863384B9DF71")
				},
				new DamageReport()
				{
					Id = Guid.Parse("9F6C5E4C-9F4F-48D1-8ADB-BC842BFCA9B7"),
					Description = "Tires were slashed and the windshield has a large crack running across.",
					ReportedDate = DateTime.UtcNow.AddDays(-7),
					CostEstimation = 1800.75m,
					CarId = Guid.Parse("E3EA8915-979C-478F-B597-4B50E5F31CFD")
				}
			};

			return damageReports;
		}
	}
}
