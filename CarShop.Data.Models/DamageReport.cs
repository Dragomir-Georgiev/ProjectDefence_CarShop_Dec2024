using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarShop.Common.EntityValidationConstants.DamageReport;

namespace CarShop.Data.Models
{
    public class DamageReport
    {
        [Key]
        [Comment("Damage report unique identifier")]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Description of the damage to the car")]
        public string Description { get; set; } = null!;
        [Required]
        [Comment("Date of the reported incident")]
        public DateTime ReportedDate { get; set; }
        [Required]
        [Comment("Estimation of the cost of the repairs")]
        public decimal CostEstimation { get; set; }
        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;
    }
}
