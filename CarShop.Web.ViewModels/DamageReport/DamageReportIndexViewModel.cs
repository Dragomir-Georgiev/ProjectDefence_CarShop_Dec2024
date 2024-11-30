using System.ComponentModel.DataAnnotations;
using static CarShop.Common.EntityValidationConstants.DamageReport;

namespace CarShop.Web.ViewModels.DamageReport
{
    public class DamageReportIndexViewModel
    {
        public Guid CarId { get; set; }
        public string CarMakeModel { get; set; } = null!;
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Description must be between 50 and 500.")]
        public string? Description { get; set; }
        [Range(typeof(decimal), CostEstimationMinRange, CostEstimationMaxRange, ErrorMessage = "Cost etimation must be a positive number.")]
        public decimal? CostEstimation { get; set; }
        public DamageReportViewModel DamageReport { get; set; } = new DamageReportViewModel();
    }
}
