namespace CarShop.Web.ViewModels.DamageReport
{
    public class DamageReportViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public DateTime ReportedDate { get; set; }
        public decimal CostEstimation { get; set; } 
    }
}
