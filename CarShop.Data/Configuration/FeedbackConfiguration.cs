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
	public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
	{
		public void Configure(EntityTypeBuilder<Feedback> builder)
		{
			builder.HasData(this.SeedFeedbacks());
		}

		private List<Feedback> SeedFeedbacks()
		{
			List<Feedback> feedbacks = new List<Feedback>()
			{
				new Feedback
				{
					Id = Guid.NewGuid(),
					CarId = Guid.Parse("29480900-2B63-4503-8818-647FDE2A47E5"),
					ApplicationUserId = Guid.Parse("7D98BADC-6C8C-4588-A4F5-D4A43CA9D741"),
					Comment = "Great car, smooth ride!",
					Rating = 5,
					FeedbackDate = DateTime.UtcNow.AddDays(-8)
				},
				new Feedback
				{
					Id = Guid.NewGuid(),
					CarId = Guid.Parse("29480900-2B63-4503-8818-647FDE2A47E5"),
					ApplicationUserId = Guid.Parse("4C2D88CD-675A-4904-A431-23A043E8313E"),
					Comment = "The car was decent but had a few issues.",
					Rating = 2,
					FeedbackDate = DateTime.UtcNow.AddDays(-6)
				}
			};

			return feedbacks;	
		}
	}
}
