using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    [PrimaryKey(nameof(ApplicationUserId), nameof(RentalId))]
    public class ApplicationUserRental
    {
        [Comment("User unique identifier")]
        public Guid ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;
        [Comment("Rental unique identifier")]
        public Guid RentalId { get; set; }
        [ForeignKey(nameof(RentalId))]
        public Rental Rental { get; set; } = null!;
    }
}
