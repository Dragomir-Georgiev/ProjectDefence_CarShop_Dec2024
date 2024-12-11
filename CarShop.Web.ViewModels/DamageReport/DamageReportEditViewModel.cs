using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using static CarShop.Common.EntityValidationConstants.DamageReport;
using static CarShop.Common.EntityValidationMessages.DamageReport;

namespace CarShop.Web.ViewModels.DamageReport
{
    public class DamageReportEditViewModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionRequiredMessage)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Range(typeof(decimal), CostEstimationMinRange, CostEstimationMaxRange, ErrorMessage = CostEtimationRequiredMessage)]
        public decimal CostEstimation { get; set; }
    }
}
