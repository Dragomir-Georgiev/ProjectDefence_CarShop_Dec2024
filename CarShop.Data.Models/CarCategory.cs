using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static CarShop.Common.EntityValidationConstants.CarCategory;

namespace CarShop.Data.Models
{
    public class CarCategory
    {
        [Key]
        [Comment("Car category unique identifier")]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("The name of the category")]
        public string CategoryName { get; set; } = null!;
        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
