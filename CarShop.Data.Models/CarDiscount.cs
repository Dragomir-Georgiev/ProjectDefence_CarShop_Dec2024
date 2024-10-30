using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class CarDiscount
    {
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public Guid DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}
