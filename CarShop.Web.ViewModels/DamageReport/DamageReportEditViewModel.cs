using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using static CarShop.Common.EntityValidationConstants.DamageReport;

namespace CarShop.Web.ViewModels.DamageReport
{
    public class DamageReportEditViewModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Description must be between 50 and 500.")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Range(typeof(decimal), CostEstimationMinRange, CostEstimationMaxRange, ErrorMessage = "Cost etimation must be a positive number.")]
        public decimal CostEstimation { get; set; }
    }
}
