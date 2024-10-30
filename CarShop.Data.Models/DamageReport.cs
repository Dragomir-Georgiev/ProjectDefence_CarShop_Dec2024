using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class DamageReport
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime ReportedDate { get; set; }
        public decimal CostEstimation { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}
