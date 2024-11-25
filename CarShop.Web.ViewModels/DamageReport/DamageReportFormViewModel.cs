using System.Runtime.CompilerServices;

namespace CarShop.Web.ViewModels.DamageReport
{
    public class DamageReportFormViewModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal CostEstimation { get; set; }
    }
}
