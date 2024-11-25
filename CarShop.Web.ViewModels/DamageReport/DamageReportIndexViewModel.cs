namespace CarShop.Web.ViewModels.DamageReport
{
    public class DamageReportIndexViewModel
    {
        public Guid CarId { get; set; }
        public string CarMakeModel { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? CostEstimation { get; set; }
        public DamageReportViewModel DamageReport { get; set; } = new DamageReportViewModel();
    }
}
