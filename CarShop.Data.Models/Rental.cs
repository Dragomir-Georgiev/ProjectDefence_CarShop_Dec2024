﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class Rental
    {
        [Key]
        [Comment("Rental unique identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal TotalCost { get; set; }
        public ICollection<ApplicationUserRental> ApplicationUserRentals { get; set; } = new HashSet<ApplicationUserRental>();
    }
}
