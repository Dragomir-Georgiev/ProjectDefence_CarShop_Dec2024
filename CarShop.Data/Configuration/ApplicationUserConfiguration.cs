using CarShop.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Configuration
{
	public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.HasData(CreateUsers());
		}

		private List<ApplicationUser> CreateUsers() 
		{
			PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
			ApplicationUser userOne = new ApplicationUser()
			{
				Id = Guid.Parse("4C2D88CD-675A-4904-A431-23A043E8313E"),
				UserName = "User",
				NormalizedUserName = "USER",
				Email = "testuser123@gmail.com",
				NormalizedEmail = "TESTUSER123@GMAIL.COM",
				SecurityStamp = Guid.NewGuid().ToString()
			};
			ApplicationUser userTwo = new ApplicationUser()
			{
				Id = Guid.Parse("7D98BADC-6C8C-4588-A4F5-D4A43CA9D741"),
				UserName = "Dragomir",
				NormalizedUserName = "DRAGOMIR",
				Email = "dragomir@yahoo.ca",
				NormalizedEmail = "DRAGOMIR@YAHOO.CA",
				SecurityStamp = Guid.NewGuid().ToString()
			};
			ApplicationUser adminUser = new ApplicationUser()
			{
				Id = Guid.Parse("49317FF2-5AAC-426D-A8BD-D4BEE288C776"),
				UserName = "Admin",
				NormalizedUserName = "АDMIN",
				Email = "admin@example.com",
				NormalizedEmail = "ADMIN@EXAMPLE.COM",
				SecurityStamp = Guid.NewGuid().ToString()
			};
			userOne.PasswordHash = passwordHasher.HashPassword(userOne, "Test!12345");
			userTwo.PasswordHash = passwordHasher.HashPassword(userOne, "Test$12345");
			adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@123");
			List<ApplicationUser> users = new List<ApplicationUser>() { userOne, userTwo, adminUser };
			return users;
		}
	}
}
