﻿// <auto-generated />
using System;
using CarShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarShop.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarShop.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CarShop.Data.Models.ApplicationUserRental", b =>
                {
                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("User unique identifier");

                    b.Property<Guid>("RentalId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Rental unique identifier");

                    b.HasKey("ApplicationUserId", "RentalId");

                    b.HasIndex("RentalId");

                    b.ToTable("ApplicationUserRental");
                });

            modelBuilder.Entity("CarShop.Data.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Car unique identifier");

                    b.Property<Guid>("CarCategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier of the category of the car");

                    b.Property<string>("CarImage")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Picture of the car");

                    b.Property<int>("DoorsCount")
                        .HasColumnType("int")
                        .HasComment("Total amount of doors of the car");

                    b.Property<double>("FuelConsumption")
                        .HasColumnType("float")
                        .HasComment("The fuel consumption of the car");

                    b.Property<bool>("IsAvailable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasComment("Availability of the car");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Has the car been removed or not removed from the list of available rental cars");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("The brand of the company that made the car");

                    b.Property<int>("MaximumSpeed")
                        .HasColumnType("int")
                        .HasComment("Car maximum speed");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("The name of the car");

                    b.Property<decimal>("PricePerDay")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price for the car per day");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int")
                        .HasComment("Manufacturing year of the car");

                    b.Property<int>("SeatingCapacity")
                        .HasColumnType("int")
                        .HasComment("The maximum seating capacity of the car");

                    b.Property<double>("TankVolume")
                        .HasColumnType("float")
                        .HasComment("The tank volume of the car");

                    b.Property<int>("TransmissionType")
                        .HasColumnType("int")
                        .HasComment("Transmission type of the car");

                    b.HasKey("Id");

                    b.HasIndex("CarCategoryId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarShop.Data.Models.CarCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Car category unique identifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("The name of the category");

                    b.HasKey("Id");

                    b.ToTable("CarCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("591901ff-3a4b-404d-a134-def5d5204b5f"),
                            CategoryName = "SUV"
                        },
                        new
                        {
                            Id = new Guid("80fd0fb7-39ab-4adb-8b2d-1f4f42feb032"),
                            CategoryName = "Convertible"
                        },
                        new
                        {
                            Id = new Guid("760afc14-be66-47b0-ad76-c1ec28177ca7"),
                            CategoryName = "Hatchback"
                        },
                        new
                        {
                            Id = new Guid("7f28935f-f0cd-45c7-8043-cc4e2733a457"),
                            CategoryName = "Sedan"
                        },
                        new
                        {
                            Id = new Guid("2c5cf880-2c46-4c3c-b3c6-8973c97aefca"),
                            CategoryName = "Sports car"
                        },
                        new
                        {
                            Id = new Guid("30bf3a89-6f37-40dd-aa77-1dd7cd53c055"),
                            CategoryName = "Coupe"
                        },
                        new
                        {
                            Id = new Guid("aa0bcc23-4564-424f-9ffd-ee65eca655ce"),
                            CategoryName = "Pickup truck"
                        },
                        new
                        {
                            Id = new Guid("5f8f3579-3a00-44ad-943e-f326e5826a3e"),
                            CategoryName = "Roadster"
                        },
                        new
                        {
                            Id = new Guid("7c76a145-2f67-49aa-96be-488c97c532bd"),
                            CategoryName = "Minivan"
                        });
                });

            modelBuilder.Entity("CarShop.Data.Models.CarDiscount", b =>
                {
                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Car unique identifier");

                    b.Property<Guid>("DiscountId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Discount unique identifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Has the discount been deleted or not");

                    b.HasKey("CarId", "DiscountId");

                    b.HasIndex("DiscountId");

                    b.ToTable("CarDiscounts");
                });

            modelBuilder.Entity("CarShop.Data.Models.DamageReport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Damage report unique identifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CostEstimation")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Estimation of the cost of the repairs");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Description of the damage to the car");

                    b.Property<DateTime>("ReportedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date of the reported incident");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("DamageReports");
                });

            modelBuilder.Entity("CarShop.Data.Models.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Discount unique identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Description of the discount");

                    b.Property<double>("DiscountPercentage")
                        .HasColumnType("float")
                        .HasComment("Percentage of the discount for the daily price of the car");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("CarShop.Data.Models.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Feedback unique identifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Feedback comment from user for the car");

                    b.Property<DateTime>("FeedbackDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CarId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("CarShop.Data.Models.Rental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Rental unique identifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarShop.Data.Models.ApplicationUserRental", b =>
                {
                    b.HasOne("CarShop.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserRentals")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CarShop.Data.Models.Rental", "Rental")
                        .WithMany("ApplicationUserRentals")
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("CarShop.Data.Models.Car", b =>
                {
                    b.HasOne("CarShop.Data.Models.CarCategory", "CarCategory")
                        .WithMany("Cars")
                        .HasForeignKey("CarCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarCategory");
                });

            modelBuilder.Entity("CarShop.Data.Models.CarDiscount", b =>
                {
                    b.HasOne("CarShop.Data.Models.Car", "Car")
                        .WithMany("CarDiscounts")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CarShop.Data.Models.Discount", "Discount")
                        .WithMany("CarDiscounts")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Discount");
                });

            modelBuilder.Entity("CarShop.Data.Models.DamageReport", b =>
                {
                    b.HasOne("CarShop.Data.Models.Car", "Car")
                        .WithMany("DamageReports")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarShop.Data.Models.Feedback", b =>
                {
                    b.HasOne("CarShop.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarShop.Data.Models.Car", "Car")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarShop.Data.Models.Rental", b =>
                {
                    b.HasOne("CarShop.Data.Models.Car", "Car")
                        .WithMany("Rentals")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("CarShop.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("CarShop.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarShop.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("CarShop.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarShop.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserRentals");

                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("CarShop.Data.Models.Car", b =>
                {
                    b.Navigation("CarDiscounts");

                    b.Navigation("DamageReports");

                    b.Navigation("Feedbacks");

                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("CarShop.Data.Models.CarCategory", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarShop.Data.Models.Discount", b =>
                {
                    b.Navigation("CarDiscounts");
                });

            modelBuilder.Entity("CarShop.Data.Models.Rental", b =>
                {
                    b.Navigation("ApplicationUserRentals");
                });
#pragma warning restore 612, 618
        }
    }
}
