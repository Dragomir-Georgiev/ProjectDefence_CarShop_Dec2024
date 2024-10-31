using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarShop.Common.EntityValidationConstants.Discount;
namespace CarShop.Data.Models
{
    public class Discount
    {
        [Key]
        [Comment("Discount unique identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Description of the discount")]
        public string Description { get; set; } = null!;
        [Required]
        [Comment("Percentage of the discount for the daily price of the car")]
        public double DiscountPercentage { get; set; }
    }
}
