using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class Discount
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
