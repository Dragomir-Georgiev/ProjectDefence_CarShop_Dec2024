using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Web.ViewModels.Rental
{
    public class RentedCarViewModel
    {
        public Guid RentalId { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public string CarImage { get; set; } = null!;
    }
}
