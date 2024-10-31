using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    [PrimaryKey(nameof(CarId), nameof(DiscountId))]
    public class CarDiscount
    {
        [Comment("Car unique identifier")]
        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;
        [Comment("Discount unique identifier")]
        public Guid DiscountId { get; set; }
        [ForeignKey(nameof(DiscountId))]
        public Discount Discount { get; set; } = null!;
        [Comment("Has the discount been deleted or not")]
        public bool IsDeleted { get; set; }
    }
}
