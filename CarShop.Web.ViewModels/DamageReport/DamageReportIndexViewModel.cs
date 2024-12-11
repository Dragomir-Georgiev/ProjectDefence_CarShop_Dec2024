using System.ComponentModel.DataAnnotations;
using static CarShop.Common.EntityValidationConstants.DamageReport;
using static CarShop.Common.EntityValidationMessages.DamageReport;

namespace CarShop.Web.ViewModels.DamageReport
{
    public class DamageReportIndexViewModel
    {
        public Guid CarId { get; set; }
        public string CarMakeModel { get; set; } = null!;
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionRequiredMessage)]
        public string? Description { get; set; }
        [Range(typeof(decimal), CostEstimationMinRange, CostEstimationMaxRange, ErrorMessage = CostEtimationRequiredMessage)]
        public decimal? CostEstimation { get; set; }
        public DamageReportViewModel DamageReport { get; set; } = new DamageReportViewModel();
    }
}
